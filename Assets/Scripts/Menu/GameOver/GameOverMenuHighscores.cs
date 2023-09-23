using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using TMPro;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameOverMenuHighscores : MonoBehaviour {
    float _score;
    public string Username;
    TextMeshProUGUI _inputField;
    Button _submitButton;

    void Start() {
        _score = float.Parse(PlayerPrefs.GetFloat("score").ToString("n2"));
        Debug.Log(_score.ToString());
        _inputField = GameObject.Find("Text - Username").GetComponent<TextMeshProUGUI>();
        _submitButton = GameObject.Find("Button - SubmitScore").GetComponent<Button>();
    }

    void Update() {
        Username = _inputField.GetParsedText();
        EvalName();
    }

    public void EvalName(){
        Regex usernameMatcher = new("[a-zA-Z]{4,10}");
        _submitButton.interactable = usernameMatcher.IsMatch(_inputField.GetParsedText());
    }

    public void OnSubmit(){
        StartCoroutine(SendRequest());
    }

    IEnumerator SendRequest(){
        WWWForm form = new();
        form.AddField("userName",Username);
        form.AddField("highscore",_score.ToString().Replace(".",","), Encoding.UTF8);

        UnityWebRequest request = UnityWebRequest.Post("http://localhost:5118/api/ScoreBoard/NewScoreForm", form);
        yield return request.SendWebRequest();
        Debug.Log(request.result);
    }


   
}
