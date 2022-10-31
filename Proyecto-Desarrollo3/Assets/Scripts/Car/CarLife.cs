using UnityEngine;
using System;

public class CarLife : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    [SerializeField] private ParticleSystem explosion;

    public event Action<int, int> OnTakeDamage;
    public event Action<int, int> OnIncreaseLife;
    public event Action OnDead;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
        {
            return;
        }
        Debug.Log("decrease life");

        currentHealth -= damage;
        OnTakeDamage?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    public void IncreaseLife()
    {
        Debug.Log("increase life");
        currentHealth += 5;
        OnIncreaseLife?.Invoke(currentHealth, maxHealth);
    }
    public void Dead()
    {
        OnDead?.Invoke();
        Debug.Log("Muerto");
        explosion.Play();
        Destroy(gameObject);
    }
}