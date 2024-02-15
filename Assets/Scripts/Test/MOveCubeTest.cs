using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MOveCubeTest : MonoBehaviour {
    public Camera cam;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Vector3 mousPos = Input.mousePosition;
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousPos);
        transform.position = (Vector2)pos;
        // Debug.Log("Mousepos: " + mousPos.x + "-"+mousPos.y);
        Debug.DrawRay((Vector2)transform.position, (Vector2)transform.TransformDirection(Vector2.down) * 100, Color.white);
    }
}
