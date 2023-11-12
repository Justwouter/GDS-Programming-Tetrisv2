using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour {
    [SerializeField] private GameObject[] spawnables;
    [SerializeField] private AudioSource fXSource;
    [SerializeField] private Transform itemContainer;
    public float Speed = 3.5F;
    private int amountOfSpawns;
    private float currentScore = 0;
    private float floorLine;
    private float startHight;
    public bool IsActive = true;

    

    void Start(){
        SpawnNext();
        floorLine = FindObjectOfType<GameOver>().transform.position.y;
        startHight = transform.position.y;
    }

    // Store score in local data for use in GameOver scene
    void OnDisable(){
        PlayerPrefs.SetFloat("score", currentScore);
    }


    public void SpawnNext() {
        if(IsActive){
            int i = Random.Range(0, spawnables.Length);
            //i = 5; // Lock microwave for camera debug
            
            currentScore = CheckBlocks()-floorLine;
            // Find & update scoreboard and move spawner if neccesary
            FindAnyObjectByType<TextMeshProUGUI>().SetText("Score: {0:2}", currentScore);
            MoveSpawnerHight();

            // Spawn Item at current Position
            GameObject spawnedItem = Instantiate(spawnables[i], transform.position, Quaternion.identity);
            
            // Place the spawned items under the spawner in hierarchy
            spawnedItem.transform.SetParent(itemContainer);
            
            amountOfSpawns++;
        }
    }

    // If the tower becomes to high, move the spawner up so it is always 5 blocks above
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

    public void PlaySound(){
        fXSource.Play();
    }

}