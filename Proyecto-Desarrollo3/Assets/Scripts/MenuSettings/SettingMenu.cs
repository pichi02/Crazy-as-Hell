using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionsDropdown;

    Resolution[] resolutions;


    [SerializeField] private TMP_Dropdown fsDropdown;
    
    private void Awake()
    {
        List<string> options = new List<string>();

        ResolutionList(options);

        fsDropdown.value = 0;
    }

    private void ResolutionList(List<string> options)
    {
        resolutions = Screen.resolutions;

        resolutionsDropdown.ClearOptions();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
    }

    public void SetFullscreenMode()
    {
        if (fsDropdown.options[fsDropdown.value].text == "Fullscreen Window")
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            Debug.Log("Fullscreen Window");
            Screen.fullScreen = true;
        }
        else if (fsDropdown.options[fsDropdown.value].text == "Exclusive Fullscreen")
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            Debug.Log("Exclusive Fullscreen");
            Screen.fullScreen = true;
        }
        else if (fsDropdown.options[fsDropdown.value].text == "Maximized Window")
        {
            Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
            Debug.Log("Maximized Window");
            Screen.fullScreen = false;
        }
        else if (fsDropdown.options[fsDropdown.value].text == "Windowed")
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Debug.Log("Windowed");
            Screen.fullScreen = false;
        }
    }

    public void SetResoltuion(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
