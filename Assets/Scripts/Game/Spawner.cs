using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour {
    public GameObject[] Spawnables;
    public float Speed = 3.5F;
    private int _amountOfSpawns;
    private float _currentScore = 0;
    private float _floorLine;
    private float _startHight;
    public bool IsActive = true;

    

    void Start(){
        SpawnNext();
        _floorLine = FindObjectOfType<GameOver>().transform.position.y;
        _startHight = transform.position.y;
    }

    // Store score in local data for use in GameOver scene
    void OnDisable(){
        PlayerPrefs.SetFloat("score", _currentScore);
    }


    public void SpawnNext() {
        if(IsActive){
            int i = Random.Range(0, Spawnables.Length);
            // i = 3; // Lock microwave for camera debug
            
            _currentScore = CheckBlocks()-_floorLine;
            // Find & update scoreboard and move spawner if neccesary
            FindAnyObjectByType<TextMeshProUGUI>().SetText("Score: {0:2}", _currentScore);
            MoveSpawnerHight();

            // Spawn Item at current Position
            GameObject spawnedItem = Instantiate(Spawnables[i], transform.position, Quaternion.identity);
            
            // Place the spawned items under the spawner in hierarchy
            spawnedItem.transform.SetParent(transform);
            
            _amountOfSpawns++;
        }
    }

    // If the tower becomes to high, move the spawner up so it is always 5 blocks above
    private void MoveSpawnerHight(){
        float newYPos = transform.position.y;
        float highestBlock = CheckBlocks();
        
        if(highestBlock > transform.position.y-5){
            newYPos = highestBlock+5;
        }
        if(highestBlock < _startHight-5){
            newYPos = _startHight;
        }

        transform.position = new Vector2(transform.position.x,newYPos);
    }

    // Find the highest point in the tower
    private float CheckBlocks(){
        float highestY = 0;
        foreach(Spawnable go in FindObjectsOfType<Spawnable>()){
            if(go.transform.position.y > highestY){
                highestY = go.transform.position.y;
            }
        }
        return highestY;
    }

}