using System;
using UnityEngine;

public class SpeedWay : MonoBehaviour
{
    public event Action OnWin;
    [SerializeField] private int maxLaps;

    public void LapsToWin(int currentLaps)
    {
        if (maxLaps <= currentLaps)
        {
            OnWin?.Invoke();
            Debug.Log("Gano");
        }
    }
}
