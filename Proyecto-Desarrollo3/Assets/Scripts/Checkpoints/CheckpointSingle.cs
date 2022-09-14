using UnityEngine;

public class CheckpointSingle : MonoBehaviour
{
    private TrackCheckpoint trackCheckpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Chasis"))
        {
            trackCheckpoint.PlayerThroughCheckpoint(this);
        }
    }

    public void SetTrackCheckpoints(TrackCheckpoint trackCheckpoint)
    {
        this.trackCheckpoint = trackCheckpoint;
    }
}
