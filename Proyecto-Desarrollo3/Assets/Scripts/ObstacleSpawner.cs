
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles;

    public event System.Action<Vector3> OnSpawnObject;

    private float timer = 0;

    bool inCooldown;

    const int cooldownTime = 10;

    private bool isObstacleSpawned;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isObstacleSpawned = false;
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {
                if (!inCooldown)
                {
                    OnSpawnObject?.Invoke(hitInfo.point);
                    if (isObstacleSpawned)
                    {
                        inCooldown = true;

                    }
                }

            }
        }
        if (inCooldown)
        {
            timer += Time.deltaTime;
        }
        if (timer > cooldownTime)
        {
            inCooldown = false;
            timer = 0;
        }
        Debug.Log(timer);
    }
    public void SpawnObstacle(Vector3 pos)
    {
        isObstacleSpawned = true;
        int random = Random.Range(0, obstacles.Count);

        GameObject bojeInstance = Instantiate(obstacles[random], pos, Quaternion.identity);
    }





}
