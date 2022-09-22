using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour
{
    TYPE type;
    private System.Random randGen = new System.Random();
    private int random;

    private bool picked;

    private float timer;

    public static event System.Action OnIncreaseLifePowerUpPick;

    public static event System.Action OnDecreaseLifePowerUpPick;

    public static event System.Action OnIncreaseSpeedPowerUpPick;

    public static event System.Action OnDecreaseSpeedPowerUpPick;

    public static event System.Action OnDisableDecreaseSpeedPowerUp;

    public static event System.Action OnDisableIncreaseSpeedPowerUp;
    private void Start()
    {
        timer = 0;
        random = randGen.Next(0, 2);
        type = TYPE.INCREASE_SPEED;
    }
    //private void Update()
    //{
    //    Debug.Log(timer);
    //    if (picked)
    //    {
    //        timer += Time.deltaTime;
    //    }
    //    if (timer >= 10.0f)
    //    {
    //        if (type == TYPE.INCREASE_LIFE)
    //        {
    //            OnDisableIncreaseSpeedPowerUp?.Invoke();
    //        }
    //        else if (type == TYPE.DECREASE_LIFE)
    //        {
    //            OnDisableDecreaseSpeedPowerUp?.Invoke();
    //        }
    //    }
    //}
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
                case TYPE.INCREASE_SPEED:
                    OnIncreaseSpeedPowerUpPick?.Invoke();
                    break;
                case TYPE.DECREASE_SPEED:
                    OnDecreaseSpeedPowerUpPick?.Invoke();
                    break;
                default:
                    break;
            }
            Destroy(this);
        }
    }

}
