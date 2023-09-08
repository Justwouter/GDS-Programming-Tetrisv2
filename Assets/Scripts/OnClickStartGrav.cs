using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickStartGrav : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Physics.gravity *= -1;
        }
    }

    void OnCollision(){
        // rb.velocity = new Vector3(0,10,0);
        Debug.Log("Collision detected! Stopping gravity");
        rb.useGravity = false;
        rb.velocity = new Vector3(0,1,0);
    }
}
