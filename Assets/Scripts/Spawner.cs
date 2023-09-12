using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    // Groups
    public GameObject[] groups;
    public List<GameObject> blocksInScene;

    // Start is called before the first frame update
    void Start(){
        SpawnNext();
    }

    // Update is called once per frame
    void Update(){}

    public void SpawnNext() {
    // Random Index
        Debug.Log("Spawn triggered!");
        int i = Random.Range(0, groups.Length);
        // Spawn Group at current Position
        GameObject newObject = groups[i];
        Instantiate(newObject, transform.position, Quaternion.identity);
        blocksInScene.Add(newObject);
        MoveSpawnerHight();

    }

    private void MoveSpawnerHight(){
        float newYPos = transform.position.y;
        float highestBlock = CheckBlocks();
        
        if(highestBlock > transform.position.y-5){
            newYPos = highestBlock+5;
        }

        transform.position.Set(transform.position.x,newYPos,transform.position.z);
    }
    private float CheckBlocks(){
        float highestY = 0;
        foreach(GameObject go in blocksInScene){
            if(go.transform.position.y > highestY){
                highestY = go.transform.position.y;
            }
        }
        return highestY;
    }

}
