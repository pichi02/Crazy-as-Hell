
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
    [SerializeField] private CardsDeck deck;

    [SerializeField] private CarController player1;

    public event Action<float> OnSetCooldown;

    bool inCooldown;

    const int cooldownTime = 5;
    private float cooldown = 5;

    private bool isObstacleSpawned;
    private bool isObstacleSelected;

    [SerializeField] private LayerMask layer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!Utils.IsPointerOverUIObject(Input.mousePosition))
            {
                if (deck.GetSelectedCard() != null)
                {
                    RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), 500, layer);

                    if (hits != null && hits.Length > 0)
                    {
                        if (!inCooldown)
                        {
                            if (CanSpawnInPoint(hits[0].point))
                            {
                                SpawnObject(hits[0].point);

                                if (isObstacleSpawned)
                                {
                                    Debug.Log(hits[0].transform.gameObject.layer);
                                    StartCoroutine(DisableCooldown());

                                }
                            }
                        }
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

    public void SpawnObstacle(Vector3 pos, Vector3 lookAt)
    {
        isObstacleSpawned = true;

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
        GameObject bojeInstance = null;

        for (int i = 0; i < deck.GetDeck().Count; i++)
        {
            if (deck.GetDeck()[i].GetIsClicked())
            {
                Vector3 aux = deck.GetDeck()[i].transform.position;
                deck.GetDeck()[i].transform.position = deck.GetNextCards()[0].transform.position;
                deck.GetNextCards()[0].transform.position = aux;

                bojeInstance = Instantiate(deck.GetDeck()[i].GetPrefab(), pos, Quaternion.identity);
                deck.GetNextCards().Add(deck.GetDeck()[i]);
                deck.GetDeck().Remove(deck.GetDeck()[i]);
                deck.GetDeck().Add(deck.GetNextCards()[0]);
                deck.GetNextCards().Remove(deck.GetNextCards()[0]);
            }
        }
    }

    public bool CanSpawnInPoint(Vector3 pos)
    {
        return Vector3.Distance(pos, player1.transform.position) > player1.SafeZone;
    }

    private void SpawnObject(Vector3 pos)
    {
        if (player1)
        {
            SpawnObstacle(pos, player1.GetPosition());
        }
    }
}