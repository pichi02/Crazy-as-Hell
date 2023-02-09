using UnityEngine;

public class CollisionWithObstacle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleCollision;
    [SerializeField] private ParticleSystem particleCollisionPowerup;

    float timer = 0;
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
            Debug.Log("sangre");
        }
    }
}
