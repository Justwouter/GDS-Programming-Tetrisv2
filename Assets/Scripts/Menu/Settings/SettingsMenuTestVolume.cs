using UnityEngine;

public class SettingsMenuTestVolume : MonoBehaviour {
    public AudioSource Jukebox;
    public void OnButtonPressed() {
        if (Jukebox.isPlaying) {
            Jukebox.Stop();
        }
        else {
            Jukebox.Play();
        }
    }
}
