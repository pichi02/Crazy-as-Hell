using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class sfxSlide : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    private float volume;

    public void VolumeSlider(float volume)
    {
        AkSoundEngine.SetRTPCValue("SFX_Volume", volume);
        volumeSlider.value = volume;
        AudioManager.SfxVolume = volume;
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }
    public void UpdateVolume()
    {
        volumeSlider.value = AudioManager.SfxVolume;
    }
}
