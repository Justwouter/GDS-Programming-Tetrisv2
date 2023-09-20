using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraCollision : MonoBehaviour
{
    BoxCollider2D _boxC2D;
    Spawner spawner;
    public float add;
    public Vector3 colliderBounds;
    void Start(){
        _boxC2D = GetComponent<BoxCollider2D>();
        spawner = FindAnyObjectByType<Spawner>();
    }

    
    void Update()
    {
        if(spawner.transform.position.y > _boxC2D.size.y){
            // Get the y offset from the center of box
            add = spawner.transform.position.y - ((_boxC2D.size.y + _boxC2D.offset.y)/2);

            // Add the half of the new amount as offset to keep bottom in same place
            _boxC2D.offset = new Vector2(0,_boxC2D.offset.y+(add/2));

            // Add full amount too the box
            _boxC2D.size = new Vector2(_boxC2D.size.x, _boxC2D.size.y+add);
        }
        
        
    }
}
