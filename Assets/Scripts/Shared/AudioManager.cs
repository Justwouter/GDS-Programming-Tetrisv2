using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] AudioSource musicSource, fxSource;
    void Awake() {
        musicSource.volume = PlayerPrefs.GetFloat("IplayerMusicVolume");
        fxSource.volume = PlayerPrefs.GetFloat("IplayerFXVolume");
    }

    public void PlayFX() {
        fxSource.Play();
    }
    public void StopFX() {
        fxSource.Stop();
    }
    public bool IsFXPlaying() {
        return fxSource.isPlaying;
    }

    public void SetFXVolume(float volume) {
        fxSource.volume = volume;
    }

    public void PlayMusic() {
        musicSource.Play();
    }
    public void StopMusic() {
        musicSource.Stop();
    }
    public bool IsMusicPlaying() {
        return musicSource.isPlaying;
    }
    public void SetMusicVolume(float volume) {
        musicSource.volume = volume;
    }
}
