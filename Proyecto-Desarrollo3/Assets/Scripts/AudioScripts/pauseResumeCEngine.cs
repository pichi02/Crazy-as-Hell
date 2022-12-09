using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseResumeCEngine : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                AkSoundEngine.PostEvent("Resume_car_engine", gameObject);
            else
                AkSoundEngine.PostEvent("Pause_car_engine", gameObject);
        }
    }
            
}
