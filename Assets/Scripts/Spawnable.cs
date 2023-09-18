using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities.UniversalDelegates;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Spawnable : MonoBehaviour
{
    private Rigidbody2D rb;
    float SpawnTime = 0;
    bool hasDropped = false;
    Vector2 movement = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = -0;
        rb.Sleep(); //Needed to avoid the slowfalling on first spawn
        SpawnTime = Time.time;
    }

    void Update()
    {
        if(!hasDropped){
            transform.Translate(FindAnyObjectByType<Spawner>().speed * Time.deltaTime * movement);
        }
        
        // Spawn next item when current item becomes stationary.
        if (rb.velocity.magnitude <= 0.01f && Time.time - SpawnTime > 1 && hasDropped){
            Debug.Log("I trigger");
            FindAnyObjectByType<Spawner>().SpawnNext();
            enabled = false;
        }

        
    }


    //Input
    void OnMove(InputValue inputValue){
        movement = inputValue.Get<Vector2>();
    }
    void OnDrop(InputValue inputValue){
        EnableGravity();
    }


    // Helpers
    void EnableGravity(){
        rb.gravityScale = 1;
        rb.WakeUp();
        SpawnTime = Time.time;
        hasDropped = true;
    }
}
