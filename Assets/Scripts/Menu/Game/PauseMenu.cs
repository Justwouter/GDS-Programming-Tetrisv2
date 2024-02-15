using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public void OnQuit() {
        // Reset to normal state before unloading
        FindAnyObjectByType<PauseController>().HandlePauseSwitch();
        SceneManager.LoadScene("MainMenu");
    }

    public void OnResume() {
        FindAnyObjectByType<PauseController>().HandlePauseSwitch();
    }
}
