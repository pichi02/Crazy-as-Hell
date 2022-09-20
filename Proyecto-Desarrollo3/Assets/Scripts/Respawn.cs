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

    private Quaternion initialRot;

    private void Awake()
    {
        initialRot = player.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Chasis"))
        {
            sphere.transform.position = trackCheckpoint.vectorPoint;
            player.transform.forward = trackCheckpoint.directionPoint;
            carController.speedInput = 0;
        }
    }
}
