using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        float score = PlayerPrefs.GetFloat("score");
        GameObject.Find("Text - Score").GetComponent<TextMeshProUGUI>().SetText("{0:2} Points!", score);
    }

    public void OnPlay(){
        SceneManager.LoadScene("MainGame");
        // SceneManager.UnloadSceneAsync("GameOverMenu");
    }

    public void OnQuit(){
        SceneManager.LoadScene("MainMenu");
        // SceneManager.UnloadSceneAsync("GameOverMenu");
    }
}
