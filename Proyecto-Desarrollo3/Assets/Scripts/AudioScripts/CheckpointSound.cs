using UnityEngine;


[RequireComponent(typeof(AkGameObj))]


public class CheckpointSound : MonoBehaviour
{


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Chasis")
        {
            AkSoundEngine.PostEvent("Play_Checkpoint", gameObject);
        }
            
    }
}
