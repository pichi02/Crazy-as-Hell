using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class carEngineSound : MonoBehaviour
{

    public Rigidbody TheCar;
    private float TheSpeed;


    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("Play_car_engine", gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        TheSpeed = TheCar.velocity.magnitude;
        
        AkSoundEngine.SetRTPCValue("RTPC_CarSpeed", TheSpeed, gameObject);


    }
}
