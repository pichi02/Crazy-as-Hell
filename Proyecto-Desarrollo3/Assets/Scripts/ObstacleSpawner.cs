using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle1;
    [SerializeField] private GameObject obstacle2;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {
                GameObject BojeInstance;
                BojeInstance = Instantiate(obstacle1, hitInfo.point, Quaternion.identity) as GameObject;

            }
        }
    }

}
