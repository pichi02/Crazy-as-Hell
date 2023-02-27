using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AkGameObj))]

public class ClickSounds : MonoBehaviour
{
    [SerializeField] private string eventoWwise;
    public void PlayButtonSFX()
    {
        AkSoundEngine.PostEvent(eventoWwise, gameObject);
    }
}
