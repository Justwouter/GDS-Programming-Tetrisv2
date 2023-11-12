using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;

using Unity.Entities;
using Unity.Entities.UniversalDelegates;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreBoardGeneral : MonoBehaviour {
    [SerializeField] private int amountOfRows = 5;
    public GameObject RowPrefab;


    void Start() {
        StartCoroutine(GetScoreboard());
    }

    // void Update() {

        // if(Input.GetKeyDown(KeyCode.E)){
        //    GameObject newRow = Instantiate(rowPrefab);
        //    newRow.transform.SetParent(transform);
        //    newRow.transform.localScale = new Vector3(1,1,1);
        // }
        // if(Input.GetKeyDown(KeyCode.R)){
        //     for(int i = 0; i < transform.childCount;i++){
        //         GameObject child = transform.GetChild(i).gameObject;
        //         if(child.GetComponent<ScoreBoardRow>() != null){
        //             child.GetComponent<ScoreBoardRow>().SetRowData(Random.Range(1,100f),"Boris Dzhardjermeshivelli");
        //         }
        //     }
        // }
    // }


    IEnumerator GetScoreboard() {
        for (int i = 0; i < amountOfRows; i++) {
            UnityWebRequest request = UnityWebRequest.Get("https://tetrisapi.swijnenburg.cc/api/ScoreBoard/GetScoreBoardEntry/" + i);
            yield return request.SendWebRequest();

            if (request.responseCode == 200) {
                Debug.Log(request.downloadHandler.text);
                ScoreboardEntry entry = JsonUtility.FromJson<ScoreboardEntry>(request.downloadHandler.text);
                CreateRowWithValues((float)entry.highscore, entry.userName);
            }
        }
    }



    private void CreateRowWithValues(float score, string name) {
        GameObject newRow = Instantiate(RowPrefab);
        newRow.transform.SetParent(transform);
        newRow.transform.localScale = new Vector3(1, 1, 1);
        newRow.GetComponent<ScoreBoardRow>()
            .SetRowData(score, name);

    }


    // #region Hacky inner classes to allow the unity JSON deserializer to work
    [Serializable]
    private class ScoreboardEntry {
        public int id;
        public string userName;
        public double highscore;

    }
    //#endregion
}
