using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CarLife carLife;
    [SerializeField] private Obstacle obstacle;

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
    }

    private void Update()
    {
        vueltas.text = "Vueltas " + index;
    }
}
