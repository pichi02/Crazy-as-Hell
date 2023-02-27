using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private static musicSlide musicSlider;
    private static sfxSlide sfxSlider;
    private static muteAudio mute;
    private static float musicVolume;
    private static float sfxVolume;


    public static float MusicVolume
    {
        get { return musicVolume; }
        set { musicVolume = value; }
    }
    public static float SfxVolume
    {
        get { return sfxVolume; }
        set { sfxVolume = value; }
    }
    private void Awake()
    {

    }
    private void Start()
    {
        sfxSlider.VolumeSlider(PlayerPrefs.GetFloat("sfxVolume", 100));
        musicSlider.VolumeSlider(PlayerPrefs.GetFloat("musicVolume", 100));
        mute.MuteToggle(Convert.ToBoolean(PlayerPrefs.GetInt("mute")));
        

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static void SetSettings(musicSlide musicSlide, sfxSlide sfxSlide, muteAudio muteAudio)
    {
        musicSlider = musicSlide;
        sfxSlider = sfxSlide;
        mute = muteAudio;
    }

}

