using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuResolutionChoice : MonoBehaviour {
    private Resolution[] _availableResolutions;
    [SerializeField] private TMP_Dropdown _resolutionSelector;
    Resolution _selectedRes;
    void Awake() {

        // Use unity's api to find all (supported) resolutions
        _availableResolutions = Screen.resolutions;

        _resolutionSelector.ClearOptions();

        // Get the name of each resolution and add them to the dropdown
        List<string> options = new();
        _availableResolutions.ToList().ForEach(a => options.Add(a.ToString()));
        _resolutionSelector.AddOptions(options);

        // Use this monster of a Linq query to find the current resolution and set it as the default
        _resolutionSelector.value = _resolutionSelector.options.IndexOf(
            _resolutionSelector.options.First(
            a => a.text == Screen.currentResolution.ToString()
            ));
    }

    public void OnResolutionSelection() {
        // Use Linq to find the currently selected resolution
        _selectedRes = _availableResolutions.ToList().First(a =>
        a.ToString() == _resolutionSelector.options[_resolutionSelector.value].text);
    }

    public void ResolutionConformation() {
        Screen.SetResolution(_selectedRes.width, _selectedRes.height, FullScreenMode.FullScreenWindow, _selectedRes.refreshRateRatio);
    }
}
