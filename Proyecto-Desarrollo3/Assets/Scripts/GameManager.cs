using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CarLife carLife;
    [SerializeField] private Obstacle obstacle;
    [SerializeField] private ObstacleSpawner player2;
    [SerializeField] private CarController player1;

    public int index;

    [SerializeField] private TextMeshProUGUI vueltas;

    private void Awake()
    {
        index = 0;
    }

    private void Start()
    {
        Obstacle.OnCarCollision += carLife.TakeDamage;
        Obstacle.OnCarCollision += carLife.Dead;
        player2.OnSpawnObject += OnSpawnObject;

    }

    private void OnSpawnObject(Vector3 pos)
    {
        if (Vector3.Distance(pos, player1.transform.position) > player1.SafeZone)
        {
            player2.SpawnObstacle(pos);
        }
    }

    private void Update()
    {
        vueltas.text = "Vueltas " + index;
    }
    private void OnDestroy()
    {
        Obstacle.OnCarCollision -= carLife.TakeDamage;
        Obstacle.OnCarCollision -= carLife.Dead;
        player2.OnSpawnObject -= OnSpawnObject;
    }
}
