using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AkGameObj))]


public class startRace : MonoBehaviour
{
    [SerializeField] private string stopMusicMenu;
    [SerializeField] private string startRaceButton;

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown("Space")) 
        {
            AkSoundEngine.PostEvent(startRaceButton, gameObject);

            AkSoundEngine.PostEvent(stopMusicMenu, gameObject);
        }
    }
}
