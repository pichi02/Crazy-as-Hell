using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CarLife carLife;
    [SerializeField] private CarController player1;
    [SerializeField] private TrackCheckpoint trackCheckpoint;
    [SerializeField] private SpeedWay speedWay;
    [SerializeField] private ObstacleSpawner player2;
    private RaceTime raceTime;
    [SerializeField] private List<ObstaclePreVisualize> preVisualizes;
    [SerializeField] private List<CardCooldown> cardsCooldown;
    [SerializeField] private FollowTarget rangeIndicator;

    private void Awake()
    {
        raceTime = GetComponent<RaceTime>();
        Time.timeScale = 1.0f;
    }
    private void Start()
    {
        PowerUp.OnIncreaseLifePowerUpPick += carLife.IncreaseLife;
        PowerUp.OnDecreaseLifePowerUpPick += carLife.TakeDamage;
        PowerUp.OnIncreaseSpeedPowerUpPick += player1.IncreaseSpeed;
        PowerUp.OnDecreaseSpeedPowerUpPick += player1.DecreaseSpeed;
        PowerUp.OnInvertInputPowerUpPick += player1.StartInvertInput;
        Obstacle.OnCarCollision += carLife.TakeDamage;
        trackCheckpoint.OnLapFinish += CheckLapsToWin;
        speedWay.OnWin += player1.DisableCarMovement;
        raceTime.OnTimeFinish += DisableCanMove;
        Obstacle.OnStun += player1.StartStun;
        speedWay.OnWin += raceTime.DisableUpdatingTime;
        speedWay.OnWin += player2.DisableCanSpawnObstacle;
        raceTime.OnTimeFinish += player2.DisableCanSpawnObstacle;
        carLife.OnDead += player2.DisableCanSpawnObstacle;
        raceTime.OnTimeFinish += player1.ResetSpeed;
        player2.OnCanSpawnObstacle += rangeIndicator.DisableIndicator;
        player2.OnCantSpawnObstacle += rangeIndicator.EnableIndicator;
        for (int i = 0; i < preVisualizes.Count; i++)
        {
            player2.OnCantSpawnObstacle += preVisualizes[i].ChangeColorToRed;
            player2.OnCanSpawnObstacle += preVisualizes[i].ChangeColorToGreen;
        }
        for (int i = 0; i < cardsCooldown.Count; i++)
        {
            player2.OnBeginCooldown += cardsCooldown[i].EnableCooldown;
            player2.OnFinishCooldown += cardsCooldown[i].DisableCooldown;
        }
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
        PowerUp.OnInvertInputPowerUpPick -= player1.StartInvertInput;
        Obstacle.OnStun -= player1.StartStun;
        raceTime.OnTimeFinish -= DisableCanMove;
        speedWay.OnWin -= raceTime.DisableUpdatingTime;
        speedWay.OnWin -= player2.DisableCanSpawnObstacle;
        raceTime.OnTimeFinish -= player2.DisableCanSpawnObstacle;
        carLife.OnDead -= player2.DisableCanSpawnObstacle;
        raceTime.OnTimeFinish -= player1.ResetSpeed;
        player2.OnCanSpawnObstacle -= rangeIndicator.DisableIndicator;
        player2.OnCantSpawnObstacle -= rangeIndicator.EnableIndicator;
        for (int i = 0; i < preVisualizes.Count; i++)
        {
            player2.OnCantSpawnObstacle -= preVisualizes[i].ChangeColorToRed;
            player2.OnCanSpawnObstacle -= preVisualizes[i].ChangeColorToGreen;
        }
        for (int i = 0; i < cardsCooldown.Count; i++)
        {
            player2.OnBeginCooldown -= cardsCooldown[i].EnableCooldown;
            player2.OnFinishCooldown -= cardsCooldown[i].DisableCooldown;
        }
    }

    private void CheckLapsToWin()
    {
        speedWay.LapsToWin(trackCheckpoint.index);
    }

    private void DisableCanMove()
    {
        player1.CanMove = false;
    }
}
