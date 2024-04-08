using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown graphicsDropdown;
    public AudioMixer AudioMixer;
    public TMP_Dropdown resolutionDropdown;


    Resolution[] resolutions;


    public void GraphicsQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
        int quality = QualitySettings.GetQualityLevel();
        Debug.Log("Updated: " + quality.ToString());

    }

    public void SetVolume(float volume){

        AudioMixer.SetFloat("volume", volume);
    
        
    }

    public void SetMute(bool isMute)
    {

        if (isMute)
        {
            AudioMixer.SetFloat("volume", -80);

        }
        else
        {
            AudioMixer.SetFloat("volume", 0);

        }

    }

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;

        List<string>options = new List<string>();

        for(int i = 0 ; i < resolutions.Length; i++){
            string option = resolutions[i].width + "x" + resolutions[i].height + ", " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
 
}
