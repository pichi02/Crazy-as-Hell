using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AK.Wwise;
using System;

public class muteAudio : MonoBehaviour
{
    [SerializeField] private Toggle muteToggle;
    public void MuteToggle(bool muted)
    {
        Debug.Log(muted);
        if (muted)
        {
            muteToggle.isOn = true;
            AkSoundEngine.PostEvent("Set_Bus_Volume_Master_Audio_Bus", gameObject);
            PlayerPrefs.SetInt("mute", Convert.ToInt32(muted));
        }
        else
        {
            muteToggle.isOn = false;
            AkSoundEngine.PostEvent("Set_Bus_Volume_Master_Audio_Bus_ON", gameObject);
            PlayerPrefs.SetInt("mute", Convert.ToInt32(muted));
        }

    }


}
