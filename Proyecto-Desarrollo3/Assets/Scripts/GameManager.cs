using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CarLife carLife;
    [SerializeField] private Obstacle obstacle;
    [SerializeField] private ObstacleSpawner player2;
    [SerializeField] private CarController player1;

    [SerializeField] private TextMeshProUGUI vueltas;


    [SerializeField] private TrackCheckpoint trackCheckpoint;

    private void Start()
    {
        Obstacle.OnCarCollision += carLife.TakeDamage;
        Obstacle.OnCarCollision += carLife.Dead;
        player2.OnSpawnObject += OnSpawnObject;
        trackCheckpoint.OnLapFinish += LapText;
    }

    private void OnSpawnObject(Vector3 pos)
    {

        if (!Utils.IsPointerOverUIObject(Input.mousePosition))
        {
            if (Vector3.Distance(pos, player1.transform.position) > player1.SafeZone)
            {
                player2.SpawnObstacle(pos);
            }
        }

    }

    private void OnDestroy()
    {
        Obstacle.OnCarCollision -= carLife.TakeDamage;
        Obstacle.OnCarCollision -= carLife.Dead;
        player2.OnSpawnObject -= OnSpawnObject;
    }

    private void LapText()
    {
        vueltas.text = "Vuelta: " + trackCheckpoint.index;
    }
}
