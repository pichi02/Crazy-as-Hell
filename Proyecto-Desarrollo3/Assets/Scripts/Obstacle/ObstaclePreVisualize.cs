using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePreVisualize : MonoBehaviour
{
    [SerializeField] Material mat;
    private bool inCooldown = false;
    public void ChangeColorToRed()
    {
        mat.color = Color.red;
    }
    public void ChangeColorToGreen()
    {
        if (!inCooldown)
        {
            mat.color = Color.green;
        }
    }

    public void SetInCooldown(bool inCooldown)
    {
        this.inCooldown = inCooldown;
    }
}
