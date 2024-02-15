using System.Collections;
using System.Text.RegularExpressions;

using TMPro;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameOverMenuHighscores : MonoBehaviour {
    private float score;
    private string username;
    private TextMeshProUGUI inputField;
    private Button submitButton;
    bool buttonUsed = false;

    void Start() {
        score = float.Parse(string.Format("{00:.00}", PlayerPrefs.GetFloat("score")));
        Debug.Log(score.ToString());
        inputField = GameObject.Find("Text - Username").GetComponent<TextMeshProUGUI>();
        submitButton = GameObject.Find("Button - SubmitScore").GetComponent<Button>();
    }

    void Update() {
        username = inputField.GetParsedText();
        EvalName();
    }

    public void EvalName() {
        Regex usernameMatcher = new(@"\b[a-zA-Z]{4,10}\b");
        if (!buttonUsed)
            submitButton.interactable = usernameMatcher.IsMatch(inputField.GetParsedText());
    }

    public void OnSubmit() {
        StartCoroutine(SendRequest());
        submitButton.enabled = false;
        buttonUsed = true;
        submitButton.interactable = false;


    }

    IEnumerator SendRequest() {
        // Send data as www-form-urlencoded to the API
        WWWForm form = new();
        form.AddField("userName", username);
        form.AddField("highscore", string.Format("{00:.00}", score));

        UnityWebRequest request = UnityWebRequest.Post("https://tetrisapi.swijnenburg.cc/api/Score/NewScoreForm", form);

        // Disable/clear inputbox as visual feedback after API request is made
        inputField.enabled = false;


        yield return request.SendWebRequest();
        Debug.Log(request.result);
    }
}
