using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardRow : MonoBehaviour{
    [SerializeField] string PlayerName;
    [SerializeField] float Score = 0.0f;

    GameObject NameText;
    GameObject ScoreText;

    void Start()
    {
        
        ScoreText = transform.GetChild(0).gameObject;
        NameText = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        
        ScoreText.GetComponent<TextMeshProUGUI>().SetText(Score.ToString());
        NameText.GetComponent<TextMeshProUGUI>().SetText(PlayerName);
    }

    public void SetRowData(float Score, String PlayerName){
        this.Score = Score;
        this.PlayerName = PlayerName;
    }
}
