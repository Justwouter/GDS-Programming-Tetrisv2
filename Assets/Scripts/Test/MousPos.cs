using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class MousPos : MonoBehaviour {
    Vector3 _mousPos;
    Vector3 _worldPos;
    public GameObject Block;
    public bool MouseHold = false;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        _mousPos = Mouse.current.position.ReadValue();
        _mousPos.z = Camera.main.nearClipPlane;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(_mousPos);
        if (worldPos != _worldPos) {
            _worldPos = worldPos;


        }

        if (MouseHold) {
            Block.transform.position = new Vector2(_worldPos.x, Block.transform.position.y);
        }


    }

    void OnMouseHold(InputValue inputValue) {
        Debug.Log("Ich werk");

        if (inputValue.isPressed) // the key has been pressed
        {
            MouseHold = true;
        }
        else //the key has been released
        {
            MouseHold = false;
        }
    }
}
