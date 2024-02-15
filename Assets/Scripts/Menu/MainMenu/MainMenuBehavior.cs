using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour {
    public void OnPlayButton() {
        if (PlayerPrefs.GetInt("HasPlayedBefore") == 1) {
            SceneManager.LoadScene("MainGame");

        }
        else {
            SceneManager.LoadScene("Tutorial");
        }
    }

    public void OnQuitButton() {
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void OnSettingsButton() {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void Test() {
        PlayerPrefs.SetInt("HasPlayedBefore", 0);
        PlayerPrefs.Save();
    }
}
