using System;
using System.Collections;
using System.Collections.Generic;

using Unity.Entities.UniversalDelegates;

using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Spawnable : MonoBehaviour {
    private Rigidbody2D rb;
    float _dropTime = 0;
    private bool _hasDropped = false;
    private bool _mouseActive = false;
    Vector2 _movement = Vector2.zero;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = -0;
        rb.Sleep(); //Needed to avoid the slowfalling on first spawn
    }

    void Update() {
        // Enable movement in pre-drop stage
        if (!_hasDropped) {


            if (_mouseActive) {
                // Read mouse location & convert from screen to game position
                Vector3 mousPos = Mouse.current.position.ReadValue();
                mousPos.z = Camera.main.nearClipPlane;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousPos);
                
                if (IsMoveValidMouse(worldPos)) {
                    transform.position = new Vector2(worldPos.x, transform.position.y);
                }

            }
            else if (IsMoveValid(_movement)) {
                transform.Translate(FindAnyObjectByType<Spawner>().speed * Time.deltaTime * new Vector2(_movement.x, 0));
            }
        }

        // Spawn next item when current item becomes stationary & at least a second has passed.
        else if (rb.velocity.magnitude <= 0.01f && Time.time - _dropTime > 1 && _hasDropped) {
            FindAnyObjectByType<Spawner>().SpawnNext();
            enabled = false;
        }


    }


    //Input
    void OnMove(InputValue inputValue) {
        _movement = inputValue.Get<Vector2>();
    }

    void OnDrop(InputValue inputValue) {
        EnableGravity();
    }

    void OnMouseHold(InputValue inputValue) {
        Debug.Log("Ich werk");

        if (inputValue.isPressed) // the key has been pressed
        {
            _mouseActive = true;
        }
        else //the key has been released
        {
            _mouseActive = false;
        }
    }




    // Helpers
    void EnableGravity() {
        rb.gravityScale = 1;
        rb.WakeUp();
        _dropTime = Time.time;
        _hasDropped = true;
    }

    bool IsMoveValid(Vector3 move) {
        // Only allow movement within the floor bounds
        GameOver floor = FindAnyObjectByType<GameOver>();
        float floorWidth = floor.GetComponent<MeshRenderer>().bounds.size.x / 2;
        return Mathf.Abs(transform.position.x + move.x) < floorWidth;
    }

    bool IsMoveValidMouse(Vector3 move) {
        // Only allow movement within the floor bounds
        GameOver floor = FindAnyObjectByType<GameOver>();
        float floorWidth = floor.GetComponent<MeshRenderer>().bounds.size.x / 2;
        return Mathf.Abs(move.x) < floorWidth;
    }
}
