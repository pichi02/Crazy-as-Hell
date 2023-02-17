using UnityEngine;
using AK.Wwise;
using System;

public class Obstacle : MonoBehaviour
{
    public delegate void CarCollided(int damage);

    public static CarCollided OnCarCollision;

    [SerializeField] private float maxTime = 3;
    [SerializeField] private int damage;
    [SerializeField] private ParticleSystem particle;

    public static Action<Transform> OnObstacleTimeFinish;

    float time = 0;

    private void Start()
    {
        particle.Play();
        AkSoundEngine.PostEvent("Play_Trap", gameObject);
        Destroy(gameObject, maxTime);
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= 3)
        {
            
        }
    }

    private void OnDestroy()
    {
        OnObstacleTimeFinish?.Invoke(transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Chasis"))
        {
            OnCarCollision?.Invoke(damage);
            Destroy(gameObject);
        }
    }
}