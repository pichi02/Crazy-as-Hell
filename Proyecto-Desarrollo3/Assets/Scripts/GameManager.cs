using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CarLife carLife;
    [SerializeField] private Obstacle obstacle;
    [SerializeField] private ObstacleSpawner player2;
    [SerializeField] private CarController player1;

    [SerializeField] private TextMeshProUGUI laps;

    [SerializeField] private TrackCheckpoint trackCheckpoint;
    [SerializeField] private SpeedWay speedWay;

    private void Start()
    {
        PowerUp.OnIncreaseLifePowerUpPick += carLife.IncreaseLife;
        PowerUp.OnDecreaseLifePowerUpPick += carLife.TakeDamage;
        PowerUp.OnIncreaseSpeedPowerUpPick += player1.IncreaseSpeed;
        PowerUp.OnDecreaseSpeedPowerUpPick += player1.DecreaseSpeed;
        Obstacle.OnCarCollision += carLife.TakeDamage;
        player2.OnSpawnObject += OnSpawnObject;
        trackCheckpoint.OnLapFinish += LapText;
        trackCheckpoint.OnLapFinish += CheckLapsToWin;
        speedWay.OnWin += player1.DisableCarMovement;

    }

    private void OnSpawnObject(Vector3 pos)
    {
        if (!Utils.IsPointerOverUIObject(Input.mousePosition))
        {
            if (player1)
            {
                if (Vector3.Distance(pos, player1.transform.position) > player1.SafeZone)
                {
                    player2.SpawnObstacle(pos, player1.GetPosition());
                }
            }
        }
    }

    private void OnDestroy()
    {
        Obstacle.OnCarCollision -= carLife.TakeDamage;
        player2.OnSpawnObject -= OnSpawnObject;
        trackCheckpoint.OnLapFinish -= LapText;
        trackCheckpoint.OnLapFinish -= CheckLapsToWin;
        speedWay.OnWin -= player1.DisableCarMovement;
        PowerUp.OnIncreaseLifePowerUpPick -= carLife.IncreaseLife;
        PowerUp.OnDecreaseLifePowerUpPick -= carLife.TakeDamage;
        PowerUp.OnIncreaseSpeedPowerUpPick -= player1.IncreaseSpeed;
        PowerUp.OnDecreaseSpeedPowerUpPick -= player1.DecreaseSpeed;
    }

    private void LapText()
    {
        laps.text = "Vuelta: " + trackCheckpoint.index + " / " + speedWay.maxLaps;
    }

    private void CheckLapsToWin()
    {
        speedWay.LapsToWin(trackCheckpoint.index);
    }
}
