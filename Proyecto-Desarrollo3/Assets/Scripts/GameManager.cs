using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CarLife carLife;
    [SerializeField] private Obstacle obstacle;
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
        trackCheckpoint.OnLapFinish += CheckLapsToWin;
        speedWay.OnWin += player1.DisableCarMovement;

    }

    private void OnDestroy()
    {
        Obstacle.OnCarCollision -= carLife.TakeDamage;
        trackCheckpoint.OnLapFinish -= CheckLapsToWin;
        speedWay.OnWin -= player1.DisableCarMovement;
        PowerUp.OnIncreaseLifePowerUpPick -= carLife.IncreaseLife;
        PowerUp.OnDecreaseLifePowerUpPick -= carLife.TakeDamage;
        PowerUp.OnIncreaseSpeedPowerUpPick -= player1.IncreaseSpeed;
        PowerUp.OnDecreaseSpeedPowerUpPick -= player1.DecreaseSpeed;
    }

    private void CheckLapsToWin()
    {
        speedWay.LapsToWin(trackCheckpoint.index);
    }
}
