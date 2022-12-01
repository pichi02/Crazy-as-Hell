using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform sphere;
    [SerializeField] private Transform player;
    [SerializeField] private CarController carController;
    [SerializeField] private TrackCheckpoint trackCheckpoint;

    private Quaternion initialRot;

    private void Awake()
    {
        initialRot = player.transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Chasis"))
        {
            sphere.transform.position = new Vector3(trackCheckpoint.vectorPoint.x, trackCheckpoint.vectorPoint.y - 3f, trackCheckpoint.vectorPoint.z);
            player.transform.forward = trackCheckpoint.directionPoint;
            carController.ResetSpeed();
        }
    }
}
