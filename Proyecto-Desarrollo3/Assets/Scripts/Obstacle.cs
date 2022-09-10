using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public delegate void CarCollided();
    public static CarCollided OnCarCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Chasis"))
        {
            OnCarCollision?.Invoke();
            Destroy(gameObject);
        }
    }
}
