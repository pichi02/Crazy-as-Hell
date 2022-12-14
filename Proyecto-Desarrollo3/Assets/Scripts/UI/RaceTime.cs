using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTime : MonoBehaviour
{
    [SerializeField] private float totalTime;

    private float currentTime = 0;
    private float finalTime = 0;

    public event System.Action OnTimeFinish;
    public event System.Action<float> OnTimeChange;
    private bool updatingTime = false;

    private void Start()
    {
        InitTime();
    }

    private void Update()
    {
        if (updatingTime)
        {
            UpdateTime();
        }
    }
    private void InitTime()
    {
        enabled = true;
        currentTime = totalTime;
    }
    private void UpdateTime()
    {
        currentTime -= Time.deltaTime;
        OnTimeChange?.Invoke(currentTime);

        if (currentTime <= 0)
        {
            enabled = false;
            OnTimeFinish?.Invoke();
        }
    }
    public void DisableUpdatingTime()
    {
        updatingTime = false;
        
    }

    public void EnableUpdatingTime()
    {
        updatingTime = true;
    }

    public float GetFinalTime()
    {
        return finalTime = totalTime - currentTime;
    }

}
