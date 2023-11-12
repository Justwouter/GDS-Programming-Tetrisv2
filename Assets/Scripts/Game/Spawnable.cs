using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Spawnable : MonoBehaviour {
    private Rigidbody2D rb;
    float dropTime = 0;
    private bool hasDropped = false;
    private bool mouseActive = false;
    private Vector2 movement = Vector2.zero;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = -0;
        rb.Sleep(); //Needed to avoid the slowfalling on first spawn
    }

    void Update() {
        // Enable movement in pre-drop stage
        if (!hasDropped) {


            if (mouseActive) {
                // Read mouse location & convert from screen to game position
                Vector3 mousPos = Mouse.current.position.ReadValue();
                mousPos.z = Camera.main.nearClipPlane;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousPos);

                if (IsMoveValidMouse(worldPos)) {
                    transform.position = new Vector2(worldPos.x, transform.position.y);
                }

            }
            else if (IsMoveValid(movement)) {
                transform.Translate(FindAnyObjectByType<Spawner>().Speed * Time.deltaTime * new Vector2(movement.x, 0));
            }
        }

        // Spawn next item when current item becomes stationary & at least a second since the drop has passed.
        else if (rb.velocity.magnitude <= 0.01f && Time.time - dropTime > 1 && hasDropped) {
            FindAnyObjectByType<Spawner>().SpawnNext();
            enabled = false;
        }


    }


    //Input
    void OnMove(InputValue inputValue) {
        movement = inputValue.Get<Vector2>();
    }

    void OnDrop(InputValue inputValue) {
        // Used to avoid the input flood after pressing buttons during pause
        if (!FindAnyObjectByType<PauseController>().WasPaused) {
            FindAnyObjectByType<Spawner>().PlaySound();
            EnableGravity();
        }
    }

    void OnMouseHold(InputValue inputValue) {
        mouseActive = inputValue.isPressed;
    }


    // Helpers
    void EnableGravity() {
        rb.gravityScale = 1;
        rb.WakeUp();
        dropTime = Time.time;
        hasDropped = true;

    }

    bool IsMoveValid(Vector3 move) {
        // Only allow movement within the floor bounds
        GameOver floor = FindAnyObjectByType<GameOver>();
        float floorWidth = floor.GetComponent<MeshRenderer>().bounds.size.x / 2;
        return Mathf.Abs(transform.position.x + move.x) < floorWidth;
    }

    bool IsMoveValidMouse(Vector3 move) {
        // Only allow movement within the floor bounds but without using the current position as mouse movement teleports the object to the mouse location
        GameOver floor = FindAnyObjectByType<GameOver>();
        float floorWidth = floor.GetComponent<MeshRenderer>().bounds.size.x / 2;
        return Mathf.Abs(move.x) < floorWidth;
    }
}
