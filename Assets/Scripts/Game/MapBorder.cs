using UnityEngine;

public class MapBorder : MonoBehaviour {

    void Update() {
        Spawner spawner = FindObjectOfType<Spawner>();

    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
        FindAnyObjectByType<GameOver>().DisableGame();
    }
}
