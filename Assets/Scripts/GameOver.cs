using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Trigger detected collision with "+other.gameObject.name);
        Debug.Log("Game over!");
        FindAnyObjectByType<Spawner>().isActive = false;
        
    }
    
}
