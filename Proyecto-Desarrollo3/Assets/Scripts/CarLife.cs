using UnityEngine;

public class CarLife : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    public event System.Action<int, int> OnTakeDamage;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage()
    {
        currentHealth -= 5;
        OnTakeDamage?.Invoke(currentHealth, maxHealth);
    }

    public void Dead()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Muerto");
        }
    }
}
