
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles;

    public event Action<Vector3> OnSpawnObject;
    public event Action<float> OnSetCooldown;

    bool inCooldown;

    const int cooldownTime = 5;
    private float cooldown = 5;

    private bool isObstacleSpawned;

    [SerializeField] private LayerMask layer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), 500, layer);

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

        if (inCooldown)
        {
            cooldown -= Time.deltaTime;
            OnSetCooldown?.Invoke(cooldown);

            if (cooldown <= 0)
            {
                cooldown = 5;
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
        int random = UnityEngine.Random.Range(0, obstacles.Count);

        List<RaycastHit> hits = new List<RaycastHit>();

        RaycastHit hit;

        if (Physics.Raycast(pos, Vector3.forward * 100, out hit))
        {
            hits.Add(hit);
            Debug.DrawLine(pos, hit.point, Color.green, 10);
        }
        if (Physics.Raycast(pos, Vector3.right * 100, out hit))
        {
            hits.Add(hit);
            Debug.DrawLine(pos, hit.point, Color.blue, 10);
        }
        if (Physics.Raycast(pos, Vector3.back * 100, out hit))
        {
            hits.Add(hit);
            Debug.DrawLine(pos, hit.point, Color.black, 10);
        }
        if (Physics.Raycast(pos, Vector3.left * 100, out hit))
        {
            hits.Add(hit);
            Debug.DrawLine(pos, hit.point, Color.red, 10);
        }

        float minDistance = float.MaxValue;
        int indexNear = 0;
        for (int i = 0; i < hits.Count; i++)
        {
            float currentDistance = Vector3.Distance(hits[i].point, pos);
            if (currentDistance < minDistance)
            {
                minDistance = currentDistance;
                indexNear = i;
            }
        }
        Vector3 direction = hits[indexNear].point - pos;

        GameObject bojeInstance = Instantiate(obstacles[random], pos, Quaternion.identity);
        bojeInstance.transform.forward =  hits[indexNear].normal.normalized;
    }
}
