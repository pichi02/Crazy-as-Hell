using UnityEngine;

public class CollisionWithObstacle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleCollision;
    [SerializeField] private ParticleSystem particleCollisionPowerup;

    public static event System.Action OnStun;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            particleCollision.Play();
            cinemachineShake.Instance.ShakeCamera(5f, .1f);
        }
        else if (collision.transform.CompareTag("BearTrap"))
        {
            OnStun?.Invoke();
            cinemachineShake.Instance.ShakeCamera(5f, .1f);
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
