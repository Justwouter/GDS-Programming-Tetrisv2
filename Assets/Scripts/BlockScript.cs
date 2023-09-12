using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickStartGrav : MonoBehaviour
{
    public Rigidbody rb;
    float SpawnTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        SpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (rb.velocity.magnitude <= 0.01f && Time.time - SpawnTime > 0.5){
            FindAnyObjectByType<Spawner>().SpawnNext();
            enabled = false;
        }

        if(Input.anyKey){
            rb.useGravity = true;
        }
    }

    void OnCollision(){
        // rb.velocity = new Vector3(0,10,0);
        Debug.Log("Collision detected! Stopping gravity");
        rb.useGravity = false;
        rb.velocity = new Vector3(0,1,0);
    }
}
