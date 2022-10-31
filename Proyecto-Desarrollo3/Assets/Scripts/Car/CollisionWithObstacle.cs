using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithObstacle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Obstacle") || collision.transform.CompareTag("BearTrap"))
        {
            particleCollision.Play();
        }
    }
}
