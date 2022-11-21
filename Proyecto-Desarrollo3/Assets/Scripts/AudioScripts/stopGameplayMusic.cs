using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AkGameObj))]


public class stopGameplayMusic : MonoBehaviour
{


    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Chasis")
        {
            AkSoundEngine.PostEvent("Stop_gameplay", gameObject);
        }

    }
}
