using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardRow : MonoBehaviour{
    [SerializeField] string _playerName;
    [SerializeField] float _score = 0.0f;

    GameObject NameText;
    GameObject ScoreText;

    void Start()
    {
        
        ScoreText = transform.GetChild(0).gameObject;
        NameText = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        
        ScoreText.GetComponent<TextMeshProUGUI>().SetText(_score.ToString());
        NameText.GetComponent<TextMeshProUGUI>().SetText(_playerName);
    }

    public void SetRowData(float score, String playerName){
        this._score = score;
        this._playerName = playerName;
    }
}
