using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithBorders : MonoBehaviour
{
    private float timer = 0;
    [SerializeField] private Respawn respawn;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chasis"))
        {
            timer += Time.deltaTime;

            if (timer >= 3)
            {
                respawn.ResetPosRot();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        timer = 0;
    }
}
