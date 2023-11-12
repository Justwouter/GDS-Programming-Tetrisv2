using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuHandleVolume : MonoBehaviour {
    [SerializeField] AudioManager aManager;
    [SerializeField] private Slider musicSlider, fxSlider;
    private float currentMusicVolume, currentFXVolume;

    void Awake() {
        currentMusicVolume = PlayerPrefs.GetFloat("IplayerMusicVolume");
        musicSlider.value = currentMusicVolume;

        currentFXVolume = PlayerPrefs.GetFloat("IplayerFXVolume");
        fxSlider.value = currentFXVolume;
    }

    

    public void FXUpdater(float value) {
        Debug.Log("Set IplayerFXVolume to " + value);
        currentFXVolume = value;
        PlayerPrefs.SetFloat("IplayerFXVolume", currentFXVolume);
        aManager.SetFXVolume(currentFXVolume);
    }

    public void MusicUpdater(float value) {
        Debug.Log("Set IplayerMusicVolume to " + value);
        currentMusicVolume = value;
        PlayerPrefs.SetFloat("IplayerVolume", currentMusicVolume);
        aManager.SetMusicVolume(currentMusicVolume);
    }

}
