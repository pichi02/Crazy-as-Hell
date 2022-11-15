using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePreVisualize : MonoBehaviour
{
    Renderer[] preVisualizes;
    void Start()
    {

        preVisualizes = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < preVisualizes.Length; i++)
        {
            if (preVisualizes[i].gameObject.tag != "Obstacle" && preVisualizes[i].gameObject.tag != "BearTrap")
            {
                preVisualizes[i] = null;
            }
            Debug.Log(preVisualizes[i]);
        }
    }
    public void ChangeColorToRed()
    {
        for (int i = 0; i < preVisualizes.Length; i++)
        {
            if (preVisualizes[i] != null)
            {
                preVisualizes[i].sharedMaterial.color = Color.red;
            }

        }
    }
    public void ChangeColorToGreen()
    {
        for (int i = 0; i < preVisualizes.Length; i++)
        {
            if (preVisualizes[i] != null)
            {
                preVisualizes[i].sharedMaterial.color = Color.green;
            }
        }
    }

}
