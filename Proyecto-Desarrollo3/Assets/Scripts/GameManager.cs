using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CarLife carLife;
    [SerializeField] private Obstacle obstacle;
    [SerializeField] private CarController player1;

    [SerializeField] private TextMeshProUGUI laps;

    [SerializeField] private TrackCheckpoint trackCheckpoint;
    [SerializeField] private SpeedWay speedWay;
    private RaceTime raceTime;


    private void Awake()
    {
        raceTime = GetComponent<RaceTime>();
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
