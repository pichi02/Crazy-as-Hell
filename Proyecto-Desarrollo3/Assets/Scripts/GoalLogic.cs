using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLogic : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Chasis"))
        {
            Debug.Log("Colisiona");
            gameManager.index++;
        }
    }
}