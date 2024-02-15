using System.Collections;
using System.Linq;

using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour {
    public bool IsPaused = false;
    public bool WasPaused = false;
    [SerializeField] private Canvas pauseMenu;
    [SerializeField] private AudioSource jukebox;
    // private bool isPauseMenuShown = false;
    void Awake() {
        pauseMenu.enabled = false;
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            HandlePauseSwitch();
        }
    }

    public void HandlePauseSwitch() {
        IsPaused = !IsPaused;
        // Time.timeScale = IsPaused ? 0 : 1;
        if (IsPaused) {
            jukebox.Pause();
            pauseMenu.enabled = true;
            DisableInput();
            Time.timeScale = 0;
        }
        else {
            jukebox.UnPause();
            pauseMenu.enabled = false;
            StartCoroutine(WaitASecond());
            EnableInput();
            Time.timeScale = 1;
        }
    }

    // Should in theory disable inputsystem. Problem being it does not.
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

    // Should in theory re-enable inputsystem.
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
    IEnumerator WaitASecond() {
        WasPaused = true;
        yield return new WaitForSecondsRealtime(0.5f);
        WasPaused = false;
    }
}
