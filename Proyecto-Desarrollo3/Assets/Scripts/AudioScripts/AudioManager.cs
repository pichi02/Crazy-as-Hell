using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] static musicSlide musicSlider;
    [SerializeField] static sfxSlide sfxSlider;
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

}

