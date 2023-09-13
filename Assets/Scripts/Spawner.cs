using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour {
    // Groups
    public GameObject[] groups;
    private int amountOfSpawns;
    private float baseLine;

    

    // Start is called before the first frame update
    void Start(){
        SpawnNext();
        baseLine = FindObjectOfType<GameOver>().transform.position.y;
    }

    // Update is called once per frame
    void Update(){}

    public void SpawnNext() {
    // Random Index
        Debug.Log("Spawn triggered!");
        // FindAnyObjectByType<TextMeshPro>().SetText("Score: "+blocksInScene.Count); //set before block spawn
        int i = Random.Range(0, groups.Length);

        
        FindAnyObjectByType<TextMeshPro>().SetText("Score: {0:2}", CheckBlocks()-baseLine);
        MoveSpawnerHight();
        // Spawn Group at current Position
        GameObject newObject = groups[i];
        Instantiate(newObject, transform.position, Quaternion.identity);
        amountOfSpawns++;
        
        
    }

    private void MoveSpawnerHight(){
        float newYPos = transform.position.y;
        float highestBlock = CheckBlocks();
        
        if(highestBlock > transform.position.y-5){
            newYPos = highestBlock+5;
        }

        transform.position = new Vector2(transform.position.x,newYPos);
    }
    private float CheckBlocks(){
        float highestY = 0;
        foreach(BlockScript go in FindObjectsOfType<BlockScript>()){
            if(go.transform.position.y > highestY){
                highestY = go.transform.position.y;
            }
        }
        return highestY;
    }


}
