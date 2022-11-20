using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AkGameObj))]

public class ClickSounds : MonoBehaviour
{
    [SerializeField] private string eventoWwise;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AkSoundEngine.PostEvent(eventoWwise, gameObject);
        }





    }
}
