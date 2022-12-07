using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class carDriftSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.A))
        {
            AkSoundEngine.PostEvent("Play_car_drift", gameObject);
        }
        if (Input.GetKeyUp(KeyCode.A) | Input.GetKeyUp(KeyCode.A))
        {
            AkSoundEngine.PostEvent("Stop_car_drift", gameObject);
        }
        

    }
}
