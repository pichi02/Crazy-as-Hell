using UnityEngine;
using AK.Wwise;

public class Obstacle : MonoBehaviour
{
    public delegate void CarCollided(int damage);

    public static CarCollided OnCarCollision;
    public static event System.Action OnStun;

    [SerializeField] private float maxTime = 3;
    [SerializeField] private int damage;
    [SerializeField] private ParticleSystem particle;

    private void Start()
    {
        particle.Play();
        AkSoundEngine.PostEvent("Play_Trap", gameObject);
        Destroy(gameObject, maxTime);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("Chasis"))
        {
            OnCarCollision?.Invoke(damage);
            Destroy(gameObject);
        }
        if (transform.CompareTag("BearTrap"))
        {
            OnStun?.Invoke();
        }
    }
}