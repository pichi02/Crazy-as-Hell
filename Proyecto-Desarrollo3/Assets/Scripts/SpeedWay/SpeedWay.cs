using System;
using UnityEngine;

public class SpeedWay : MonoBehaviour
{
    public event Action OnWin;
    public int maxLaps;

    public void LapsToWin(int currentLaps)
    {
        if (maxLaps <= currentLaps)
        {
            OnWin?.Invoke();
        }
    }
}
