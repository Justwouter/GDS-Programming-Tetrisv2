using System.Collections.Generic;
using System.Linq;

using TMPro;

using UnityEngine;

public class SettingsMenuResolutionChoice : MonoBehaviour {
    private Resolution[] availableResolutions;
    [SerializeField] private TMP_Dropdown resolutionSelector;
    private Resolution selectedRes;
    void Awake() {

        // Use unity's api to find all (supported) resolutions
        availableResolutions = Screen.resolutions;

        resolutionSelector.ClearOptions();

        // Get the name of each resolution and add them to the dropdown
        List<string> options = new();
        availableResolutions.ToList().ForEach(a => options.Add(a.ToString()));
        resolutionSelector.AddOptions(options);

        // Use this monster of a Linq query to find the current resolution and set it as the default
        resolutionSelector.value = resolutionSelector.options.IndexOf(
            resolutionSelector.options.First(
            a => a.text == Screen.currentResolution.ToString()
            ));
    }

    public void OnResolutionSelection() {
        // Use Linq to find the currently selected resolution
        selectedRes = availableResolutions.ToList().First(a =>
        a.ToString() == resolutionSelector.options[resolutionSelector.value].text);
    }

    public void ResolutionConformation() {
        Screen.SetResolution(selectedRes.width, selectedRes.height, FullScreenMode.FullScreenWindow, selectedRes.refreshRateRatio);
    }
}
