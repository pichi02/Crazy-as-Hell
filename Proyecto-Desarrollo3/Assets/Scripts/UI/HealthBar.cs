using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private CarLife carLife;

    private void Start()
    {
        carLife.OnTakeDamage += SetHeath;
        carLife.OnIncreaseLife += SetHeath;
    }

    public void SetHeath(int health, int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = health;
    }
    private void OnDestroy()
    {
        carLife.OnTakeDamage -= SetHeath;
        carLife.OnIncreaseLife -= SetHeath;
    }

    public void DisableHealthBar() 
    {
        gameObject.SetActive(false);
    }
    public void EnableHealthBar()
    {
        gameObject.SetActive(true);
    }
}
