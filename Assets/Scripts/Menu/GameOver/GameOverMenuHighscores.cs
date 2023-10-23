using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

using TMPro;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameOverMenuHighscores : MonoBehaviour {
    float _score;
    string _username;
    TextMeshProUGUI _inputField;
    Button _submitButton;
    bool _buttonUsed = false;

    void Start() {
        _score = float.Parse(PlayerPrefs.GetFloat("score").ToString("n2",CultureInfo.InvariantCulture));
        Debug.Log(_score.ToString());
        _inputField = GameObject.Find("Text - Username").GetComponent<TextMeshProUGUI>();
        _submitButton = GameObject.Find("Button - SubmitScore").GetComponent<Button>();
    }

    void Update() {
        _username = _inputField.GetParsedText();
        EvalName();
    }

    public void EvalName(){
        Regex usernameMatcher = new(@"\b[a-zA-Z]{4,10}\b");
        if(!_buttonUsed)
            _submitButton.interactable = usernameMatcher.IsMatch(_inputField.GetParsedText());
    }

    public void OnSubmit(){
        StartCoroutine(SendRequest());
        _submitButton.enabled = false;
        _buttonUsed = true;
        _submitButton.interactable = false;
        

    }

    IEnumerator SendRequest(){
        // Send data as www-form-urlencoded to the API
        WWWForm form = new();
        form.AddField("userName",_username);
        form.AddField("highscore",_score.ToString("n2",CultureInfo.InvariantCulture));

        UnityWebRequest request = UnityWebRequest.Post("https://tetrisapi.swijnenburg.cc/api/Score/NewScoreForm", form);
        
        // Disable/clear inputbox as visual feedback after API request is made
        _inputField.enabled = false;
        

        yield return request.SendWebRequest();
        Debug.Log(request.result);
    }
}
