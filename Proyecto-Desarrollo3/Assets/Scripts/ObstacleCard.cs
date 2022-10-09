using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObstacleCard : MonoBehaviour
{

    [SerializeField] private GameObject prefab;
    private bool isSelected;
    private Button button;

    private void Start()
    {
        isSelected = false;
        button = GetComponent<Button>();
    }

    public void SetIsClickedInTrue()
    {
        isSelected = true;
    }
    public void SetIsClickedInFalse()
    {
        isSelected = false;
    }
    public GameObject GetPrefab()
    {
        return prefab;
    }
    public bool GetIsClicked()
    {
        return isSelected;
    }
   
}
