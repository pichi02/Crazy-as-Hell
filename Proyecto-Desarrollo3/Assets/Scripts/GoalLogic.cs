using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLogic : MonoBehaviour
{
    public event System.Action OnGoalCollison;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Chasis"))
        {
            Debug.Log("Colisiona");
            OnGoalCollison?.Invoke();
        }
    }
}