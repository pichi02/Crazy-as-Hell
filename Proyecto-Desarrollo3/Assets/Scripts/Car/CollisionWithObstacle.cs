using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithObstacle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleCollision;
    [SerializeField] private ParticleSystem particleCollisionPowerup;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Obstacle") || collision.transform.CompareTag("BearTrap"))
        {
            particleCollision.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("PowerUp"))
        {
            particleCollisionPowerup.Play();
        }
    }
}
