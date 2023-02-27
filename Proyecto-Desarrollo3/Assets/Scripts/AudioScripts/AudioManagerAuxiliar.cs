using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AudioManagerAuxiliar : MonoBehaviour
{
    [SerializeField] private musicSlide musicSlider;
    [SerializeField] private sfxSlide sfxSlider;
    [SerializeField] private muteAudio mute;

    public Action<musicSlide, sfxSlide, muteAudio> OnAudioManagerStart;
    private void Awake()
    {
        OnAudioManagerStart += AudioManager.SetSettings;

        OnAudioManagerStart?.Invoke(musicSlider, sfxSlider, mute);

    }

    private void OnDestroy()
    {
        OnAudioManagerStart -= AudioManager.SetSettings;
    }

}
