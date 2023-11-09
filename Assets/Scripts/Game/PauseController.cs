using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour {
    public bool IsPaused = false;
    public bool WasPaused = false;
    // private bool isPauseMenuShown = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            IsPaused = !IsPaused;
            // Time.timeScale = IsPaused ? 0 : 1;

            if (IsPaused) {
                DisableInput();
                Time.timeScale = 0;
            }
            else {
                StartCoroutine(WaitASecond());
                EnableInput();
                Time.timeScale = 1;
            }
        }
    }

    private void DisableInput() {
        Spawnable[] spawnables = FindObjectsOfType<Spawnable>();
        foreach (Spawnable item in spawnables) {
            if (item.isActiveAndEnabled) {
                Debug.Log("Disabled input for: " + item.name);
                item.GetComponent<PlayerInput>().enabled = false;
                item.GetComponent<PlayerInput>().actions.ToList().ForEach(a => a.Disable());
                item.GetComponent<PlayerInput>().DeactivateInput();

            }
        }
    }
    private void EnableInput() {
        Spawnable[] spawnables = FindObjectsOfType<Spawnable>();
        foreach (Spawnable item in spawnables) {
            if (item.isActiveAndEnabled) {
                item.GetComponent<PlayerInput>().enabled = true;
                item.GetComponent<PlayerInput>().actions.ToList().ForEach(a => a.Enable());
                item.GetComponent<PlayerInput>().ActivateInput();

            }
        }
    }

    // Set the bool to false for 0.5 seconds after time is enabled.
    // Used to block inputsystems event queing during timeScale 0
    IEnumerator WaitASecond(){
        WasPaused = true;
        yield return new WaitForSecondsRealtime(0.5f);
        WasPaused = false;
    }
}
