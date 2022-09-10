using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform sphere;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private CarController carController;

    private Quaternion initialRot;

    private void Awake()
    {
        initialRot = player.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        sphere.transform.position = respawnPoint.transform.position;
        player.transform.rotation = initialRot;
        carController.speedInput = 0;
    }
}
