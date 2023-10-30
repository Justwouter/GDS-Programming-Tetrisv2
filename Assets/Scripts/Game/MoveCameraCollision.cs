using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MoveCameraCollision : MonoBehaviour {
    BoxCollider2D boxC2D;
    Spawner spawner;
    [SerializeField] private float add;
    private Vector3 colliderBounds;
    void Start() {
        boxC2D = GetComponent<BoxCollider2D>();
        spawner = FindAnyObjectByType<Spawner>();
    }


    void Update() {
        if (spawner.transform.position.y > boxC2D.size.y) {
            // Get the y offset from the center of box
            add = spawner.transform.position.y - ((boxC2D.size.y + boxC2D.offset.y) / 2);

            // Add the half of the new amount as offset to keep bottom in same place
            boxC2D.offset = new Vector2(0, boxC2D.offset.y + (add / 2));

            // Add full amount to the box
            boxC2D.size = new Vector2(boxC2D.size.x, boxC2D.size.y + add);
        }


    }
}
