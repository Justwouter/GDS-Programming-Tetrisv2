using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuHandleVolume : MonoBehaviour {

    [SerializeField] private Slider volumeSlider;
    private float currentVolume;

    void Awake() {
        currentVolume = PlayerPrefs.GetFloat("IplayerVolume");
        volumeSlider.value = currentVolume;
    }

    public void VolumeUpdater(float value) {
        Debug.Log("Set volume to " + value);
        currentVolume = value;
        PlayerPrefs.SetFloat("IplayerVolume",currentVolume);
        AudioListener.volume = currentVolume;
    }

}
