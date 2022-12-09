using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AkGameObj))]

public class stopCarEngine : MonoBehaviour
{
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Chasis")
        {
            AkSoundEngine.PostEvent("Stop_car_engine", gameObject);
        }

    }
}
