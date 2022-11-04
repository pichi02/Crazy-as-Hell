using UnityEngine;
using System;

public class PowerUp : MonoBehaviour
{
    TYPE type;
    private System.Random randGen = new System.Random();
    private int random;
    private float timer = 0;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float changeDirectionTime = 5f;

    public static event Action OnIncreaseLifePowerUpPick;
    public static event Action<int> OnDecreaseLifePowerUpPick;
    public static event Action OnIncreaseSpeedPowerUpPick;
    public static event Action OnDecreaseSpeedPowerUpPick;
    public static event Action OnInvertInputPowerUpPick;
    public static event Action<TYPE> OnPowerUpPick;


    private void Start()
    {
        random = randGen.Next(0, 5);
        type = (TYPE)random;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            speed *= -1;
            timer = 0f;
        }
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Chasis"))
        {
            OnPowerUpPick?.Invoke(type);
            Debug.Log("choco");

            switch (type)
            {
                case TYPE.INCREASE_LIFE:
                    OnIncreaseLifePowerUpPick?.Invoke();
                    break;
                case TYPE.DECREASE_LIFE:
                    OnDecreaseLifePowerUpPick?.Invoke(5);
                    break;
                case TYPE.INCREASE_SPEED:
                    OnIncreaseSpeedPowerUpPick?.Invoke();
                    break;
                case TYPE.DECREASE_SPEED:
                    OnDecreaseSpeedPowerUpPick?.Invoke();
                    break;
                case TYPE.INVERT_INPUT:
                    OnInvertInputPowerUpPick?.Invoke();
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
