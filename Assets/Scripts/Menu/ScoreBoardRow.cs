using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardRow : MonoBehaviour{
    [SerializeField] public int rank;
    [SerializeField] public String PlayerName;
    [SerializeField] public float Score;

    GameObject RankText;
    GameObject NameText;
    GameObject ScoreText;

    void Start()
    {
        RankText = transform.GetChild(0).gameObject;
        NameText = transform.GetChild(1).gameObject;
        ScoreText = transform.GetChild(2).gameObject;
    }

    void Update()
    {

        
    }

    public void SetRowData(int rank, String Name, float score){

    }
}
