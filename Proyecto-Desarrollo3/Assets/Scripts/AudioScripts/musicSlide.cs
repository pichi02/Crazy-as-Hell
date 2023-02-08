using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;
using UnityEngine.UI;
using UnityEngine.Rendering;


public class musicSlide : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    private float volume;

    public void VolumeSlider(float volume)
    {
        AkSoundEngine.SetRTPCValue("MUSIC_Volume", volume);
        volumeSlider.value = volume;
        AudioManager.MusicVolume = volume;
    }
    public void UpdateVolume()
    {
        volumeSlider.value = AudioManager.MusicVolume;

    }
}
