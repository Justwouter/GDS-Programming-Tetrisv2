using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour {
    public void OnPlayButton() {
        SceneManager.LoadScene("MainGame");
    }

    public void OnQuitButton() {
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void OnSettingsButton() {
        SceneManager.LoadScene("SettingsMenu");
    }
}
