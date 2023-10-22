using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuHandleVolume : MonoBehaviour {

    [SerializeField] private Slider _volumeSlider;
    private float _currentVolume;

    void Awake() {
        _currentVolume = PlayerPrefs.GetFloat("IplayerVolume");
        _volumeSlider.value = _currentVolume;
    }

    public void VolumeUpdater(float value) {
        Debug.Log("Set volume to " + value);
        _currentVolume = value;
        PlayerPrefs.SetFloat("IplayerVolume",_currentVolume);
        AudioListener.volume = _currentVolume;
    }

}
