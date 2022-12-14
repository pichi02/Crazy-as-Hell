using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AK.Wwise;

public class muteAudio : MonoBehaviour
{
    public void MuteToggle(bool muted)
    {
        if (muted)
        {
            AkSoundEngine.PostEvent("Set_Bus_Volume_Master_Audio_Bus", gameObject);
        }
        else
        {
            AkSoundEngine.PostEvent("Set_Bus_Volume_Master_Audio_Bus_ON", gameObject); 
        }
    }


}
