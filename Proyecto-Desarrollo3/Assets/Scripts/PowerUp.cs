using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour
{
    TYPE type;
    private System.Random randGen = new System.Random();
    private int random;

    public static event System.Action OnIncreaseLifePowerUpPick;

    public static event System.Action OnDecreaseLifePowerUpPick;
    private void Start()
    {
        random = randGen.Next(0, 2);
        type = (TYPE)random;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Chasis"))
        {
            Debug.Log("choco");
            switch (type)
            {
                case TYPE.INCREASE_LIFE:
                    OnIncreaseLifePowerUpPick?.Invoke();
                    break;
                case TYPE.DECREASE_LIFE:
                    OnDecreaseLifePowerUpPick?.Invoke();
                    break;
                //case TYPE.INCREASE_SPEED:
                //    break;
                //case TYPE.DECREASE_SPEED:
                //    break;
                default:
                    break;
            }
        }
    }

}
