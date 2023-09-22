using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class ScoreBoardGeneral : MonoBehaviour
{
    public GameObject rowPrefab;
    

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.E)){
           GameObject newRow = Instantiate(rowPrefab);
           newRow.transform.SetParent(transform);
           newRow.transform.localScale = new Vector3(1,1,1);
        }
        if(Input.GetKeyDown(KeyCode.R)){
            for(int i = 0; i < transform.childCount;i++){
                GameObject child = transform.GetChild(i).gameObject;
                if(child.GetComponent<ScoreBoardRow>() != null){
                    child.GetComponent<ScoreBoardRow>().SetRowData(Random.Range(1,100f),"Boris Dzhardjermeshivelli");
                }
            }
        }
        
    }
}
