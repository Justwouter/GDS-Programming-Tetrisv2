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
        DisableGame();
    }

    public void DisableGame(){
        // Disables spawner & removes non-dropped items if NextSpawn() triggered before gameover
        FindAnyObjectByType<Spawner>().isActive = false;
        Spawnable[] spawnedObjects = FindObjectsByType<Spawnable>(FindObjectsSortMode.None);
        foreach(Spawnable item in spawnedObjects){
            if(item.isActiveAndEnabled){
                Destroy(item);
            }
        }

    }
    
}
