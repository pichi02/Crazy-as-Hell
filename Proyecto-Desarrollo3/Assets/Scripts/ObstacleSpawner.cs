
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

    bool waitingCooldown;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {
                if (!waitingCooldown)
                {
                    OnSpawnObject?.Invoke(hitInfo.point);
                    waitingCooldown = true;
                }

            }
        }
        if (waitingCooldown)
        {
            timer += Time.deltaTime;
        }
        if (timer > 10)
        {
            waitingCooldown = false;
            timer = 0;
        }
        Debug.Log(timer);
    }
    public void SpawnObstacle(Vector3 pos)
    {
        int random = Random.Range(0, obstacles.Count);

        GameObject bojeInstance = Instantiate(obstacles[random], pos, Quaternion.identity);
    }


}
