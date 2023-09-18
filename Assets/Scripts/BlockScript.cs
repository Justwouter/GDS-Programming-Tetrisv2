using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities.UniversalDelegates;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class BlockScript : MonoBehaviour
{
    private Rigidbody2D rb;
    float SpawnTime = 0;
    bool hasDropped = false;
    Vector2 movement = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        SpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasDropped){
            transform.Translate(FindAnyObjectByType<Spawner>().speed * Time.deltaTime * movement);
        }
        
        if (rb.velocity.magnitude <= 0.01f && Time.time - SpawnTime > 1 && hasDropped){
            Debug.Log("I trigger");
            FindAnyObjectByType<Spawner>().SpawnNext();
            enabled = false;
        }

        
    }

    void OnMove(InputValue inputValue){
        movement = inputValue.Get<Vector2>();
    }
    void OnDrop(InputValue inputValue){
        EnableGravity();
    }

    void EnableGravity(){
        rb.gravityScale = 1;
        SpawnTime = Time.time;
        hasDropped = true;
    }
}
