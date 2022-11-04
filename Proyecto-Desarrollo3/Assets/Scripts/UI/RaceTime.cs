using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTime : MonoBehaviour
{
    [SerializeField] private float totalTime;

    private float currentTime;
    public event System.Action OnTimeFinish;
    public event System.Action<float> OnTimeChange;
    private bool updatingTime = true;
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

}
