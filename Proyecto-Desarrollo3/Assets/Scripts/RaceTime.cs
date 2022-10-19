using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTime : MonoBehaviour
{
    [SerializeField] private float totalTime;

    private float currentTime;
    public event System.Action OnTimeFinish;
    public event System.Action<float> OnTimeChange;

    private void Awake()
    {
        enabled = true;
    }
    private void Start()
    {
        currentTime = totalTime;
    }

    private void Update()
    {
        UpdateTime();
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
}
