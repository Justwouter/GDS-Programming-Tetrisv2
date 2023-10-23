using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuBehavior : MonoBehaviour
{
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
