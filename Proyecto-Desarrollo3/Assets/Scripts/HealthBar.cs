using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private CarLife carLife;

    private void Start()
    {
        carLife.OnTakeDamage += SetHeath;
    }

    public void SetHeath(int health, int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = health;
    }
}
