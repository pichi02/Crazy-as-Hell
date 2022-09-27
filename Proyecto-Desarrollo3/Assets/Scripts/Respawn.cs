using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform sphere;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private CarController carController;
    [SerializeField] private TrackCheckpoint trackCheckpoint;

    private float respawnTime = 1;

    private Quaternion initialRot;

    private void Awake()
    {
        initialRot = player.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Chasis"))
        {
            sphere.transform.position = new Vector3(trackCheckpoint.vectorPoint.x, 4f, trackCheckpoint.vectorPoint.z);
            player.transform.forward = trackCheckpoint.directionPoint;
            carController.ResetSpeed();
        }
    }

    //private IEnumerator RespawnInCheckpoint()
    //{
    //    carController.CanMove = false;
    //    yield return new WaitForSeconds(respawnTime);
    //    carController.CanMove = true;
    //}
}
