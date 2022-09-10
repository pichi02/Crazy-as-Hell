using UnityEngine;

public class CarLife : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    [SerializeField] private HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage()
    {
        currentHealth -= 5;

        healthBar.SetHeath(currentHealth);
    }

    public void Dead()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Muerto");
        }
    }
}
