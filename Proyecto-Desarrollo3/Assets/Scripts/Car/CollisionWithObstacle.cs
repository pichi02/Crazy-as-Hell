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
            cinemachineShake.Instance.ShakeCamera(5f, .1f);
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
