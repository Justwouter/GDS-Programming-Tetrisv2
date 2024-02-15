using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Trigger detected collision with " + other.gameObject.name);
        Debug.Log("Game over!");
        DisableGame();
    }

    public void DisableGame() {
        // Disables spawner & removes non-dropped items if NextSpawn() triggered before gameover
        FindAnyObjectByType<Spawner>().IsActive = false;
        Spawnable[] spawnedObjects = FindObjectsByType<Spawnable>(FindObjectsSortMode.None);
        foreach (Spawnable item in spawnedObjects) {
            if (item.isActiveAndEnabled) {
                Destroy(item);
            }
        }

        SceneManager.LoadScene("GameOverMenu");
        // SceneManager.UnloadSceneAsync("MainGame");

    }

}
