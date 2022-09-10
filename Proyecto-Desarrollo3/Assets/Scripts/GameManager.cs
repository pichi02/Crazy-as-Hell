using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CarLife carLife;
    [SerializeField] private Obstacle obstacle;

    private void Start()
    {
        Obstacle.OnCarCollision += carLife.TakeDamage;
    }
}
