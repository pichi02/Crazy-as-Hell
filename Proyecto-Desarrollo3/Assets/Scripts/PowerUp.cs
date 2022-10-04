using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PowerUp : MonoBehaviour
{
    TYPE type;
    private System.Random randGen = new System.Random();
    private int random;

    public static event Action OnIncreaseLifePowerUpPick;
    public static event Action OnDecreaseLifePowerUpPick;
    public static event Action OnIncreaseSpeedPowerUpPick;
    public static event Action OnDecreaseSpeedPowerUpPick;
    public static event Action<TYPE> OnPowerUpPick;


    private void Start()
    {
        random = randGen.Next(0, 4);
        type = (TYPE)random;
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.transform.CompareTag("Chasis"))
        {
            OnPowerUpPick?.Invoke(type);
            Debug.Log("choco");

            switch (type)
            {
                case TYPE.INCREASE_LIFE:
                    OnIncreaseLifePowerUpPick?.Invoke();
                    break;
                case TYPE.DECREASE_LIFE:
                    OnDecreaseLifePowerUpPick?.Invoke();
                    break;
                case TYPE.INCREASE_SPEED:
                    OnIncreaseSpeedPowerUpPick?.Invoke();
                    break;
                case TYPE.DECREASE_SPEED:
                    OnDecreaseSpeedPowerUpPick?.Invoke();
                    break;
                default:
                    break;
            }
            Destroy(gameObject);

        }
    }

}
