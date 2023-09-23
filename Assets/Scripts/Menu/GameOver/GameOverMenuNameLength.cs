using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class GameOverMenuNameLength : MonoBehaviour {

    TextMeshProUGUI _username;
    
    void Start() {
        _username = GameObject.Find("Text - Username").GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update() {
        Regex usernameMatcher = new("[a-zA-Z]{4,10}");

        // Debug.Log(usernameMatcher.IsMatch(_username.GetParsedText()));
        
    }
}
