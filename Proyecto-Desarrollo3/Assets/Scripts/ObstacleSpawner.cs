
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles;

    public event System.Action<Vector3> OnSpawnObject;

    bool inCooldown;

    const int cooldownTime = 10;

    private bool isObstacleSpawned;

    [SerializeField] private LayerMask layer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), 100, layer);

            if (hits != null && hits.Length > 0)
            {
                if (!inCooldown)
                {
                    OnSpawnObject?.Invoke(hits[0].point);
                    if (isObstacleSpawned)
                    {
                        Debug.Log(hits[0].transform.gameObject.layer);
                        StartCoroutine(DisableCooldown());
                    }
                }
            }
        }
    }

    public IEnumerator DisableCooldown()
    {
        inCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        inCooldown = false;
    }

    public void SpawnObstacle(Vector3 pos)
    {
        isObstacleSpawned = true;
        int random = Random.Range(0, obstacles.Count);

        GameObject bojeInstance = Instantiate(obstacles[random], pos, Quaternion.identity);
    }
}
