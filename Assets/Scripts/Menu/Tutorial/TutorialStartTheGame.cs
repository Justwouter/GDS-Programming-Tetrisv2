using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialStartTheGame : MonoBehaviour
{
    public void OnStart(){
        PlayerPrefs.SetInt("HasPlayedBefore",1);
        SceneManager.LoadScene("MainGame");
    }
}
