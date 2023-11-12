using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SettingsMenuTestVolumeNEW : MonoBehaviour {
    [SerializeField] private AudioManager jukebox;


    public void OnFXButtonPressed() {
        jukebox.PlayFX();
    }

    public void OnMusicButtonPressed(){
        if(jukebox.IsMusicPlaying()){
            jukebox.StopMusic();
        }
        else{
            jukebox.PlayMusic();
        }
    }
}
