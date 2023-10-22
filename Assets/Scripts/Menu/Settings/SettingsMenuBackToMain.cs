using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenuBackToMain : MonoBehaviour {
    public void OnClick() {
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    }
}
