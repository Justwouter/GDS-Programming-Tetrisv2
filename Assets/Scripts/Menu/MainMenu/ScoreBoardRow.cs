using System;

using TMPro;

using UnityEngine;

public class ScoreBoardRow : MonoBehaviour {
    [SerializeField] private string playerName;
    [SerializeField] private float score = 0.0f;

    private GameObject nameText;
    private GameObject scoreText;

    void Start() {

        scoreText = transform.GetChild(0).gameObject;
        nameText = transform.GetChild(1).gameObject;
    }

    void Update() {

        scoreText.GetComponent<TextMeshProUGUI>().SetText(score.ToString());
        nameText.GetComponent<TextMeshProUGUI>().SetText(playerName);
    }

    public void SetRowData(float score, String playerName) {
        this.score = score;
        this.playerName = playerName;
    }
}
