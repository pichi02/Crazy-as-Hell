using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Chasis"))
        {
            Destroy(collision.transform.parent.transform.parent.gameObject.GetComponent<CarController>());
            Debug.Log("choco");
        }
    }
}
