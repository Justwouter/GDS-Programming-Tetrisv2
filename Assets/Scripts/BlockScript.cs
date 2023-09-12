using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities.UniversalDelegates;
using UnityEngine;

public class OnClickStartGrav : MonoBehaviour
{
    public Rigidbody2D rb;
    float SpawnTime = 0;
    bool hasDropped = false;
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
        if(Input.anyKey){
            EnableGravity();
        }

        if(!hasDropped){
            Vector2 mousPosition = Input.mousePosition;
            transform.position = new Vector2(mousPosition.x,mousPosition.y);
        }

        if (rb.velocity.magnitude <= 0.01f && Time.time - SpawnTime > 1 && hasDropped){
            Debug.Log("I trigger");
            FindAnyObjectByType<Spawner>().SpawnNext();
            enabled = false;
        }

        
    }

    void OnCollision(){
        // rb.velocity = new Vector3(0,10,0);
        Debug.Log("Collision detected! Stopping gravity");
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0,1);
    }
    void EnableGravity(){
        rb.gravityScale = 1;
        SpawnTime = Time.time;
        hasDropped = true;
    }
}
