using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour {
    public GameObject[] spawnables;
    public float speed = 2;
    private int amountOfSpawns;
    private float floorLine;
    private float startHight;

    private Vector2 movement = Vector2.zero;

    

    void Start(){
        SpawnNext();
        floorLine = FindObjectOfType<GameOver>().transform.position.y;
        startHight = transform.position.y;
    }

    void Update(){
        transform.Translate(speed * Time.deltaTime * movement);
    }

    public void SpawnNext() {
        Debug.Log("Spawn triggered!");
        int i = Random.Range(0, spawnables.Length);

        // Find & update scoreboard and move spawner if neccesary
        FindAnyObjectByType<TextMeshPro>().SetText("Score: {0:2}", CheckBlocks()-floorLine);
        MoveSpawnerHight();

        // Spawn Item at current Position
        Instantiate(spawnables[i], transform.position, Quaternion.identity);
        amountOfSpawns++;
    }

    private void MoveSpawnerHight(){
        float newYPos = transform.position.y;
        float highestBlock = CheckBlocks();
        
        if(highestBlock > transform.position.y-5){
            newYPos = highestBlock+5;
        }
        if(highestBlock < startHight-5){
            newYPos = startHight;
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
