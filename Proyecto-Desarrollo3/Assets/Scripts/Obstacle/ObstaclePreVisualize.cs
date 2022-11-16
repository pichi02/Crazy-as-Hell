using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePreVisualize : MonoBehaviour
{
    [SerializeField] Material mat;

    public void ChangeColorToRed()
    {
        mat.color = Color.red;
    }
    public void ChangeColorToGreen()
    {
        mat.color = Color.green;
    }

}
