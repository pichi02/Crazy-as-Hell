using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public delegate void CarCollided();
    public static CarCollided OnCarCollision;
    private float timer = 0;
    [SerializeField] private float maxTime = 7;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Chasis"))
        {
            OnCarCollision?.Invoke();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > maxTime)
            Destroy(gameObject);
    }
}