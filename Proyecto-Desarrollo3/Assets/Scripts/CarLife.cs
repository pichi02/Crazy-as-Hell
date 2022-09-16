using UnityEngine;

public class CarLife : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private MeshRenderer meshRenderer;

    [SerializeField] private ParticleSystem explosion;

    public event System.Action<int, int> OnTakeDamage;

    private void Start()
    {
        currentHealth = maxHealth;
        explosion.Pause();
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
            explosion.Play();
            Destroy(gameObject);
        }
    }
}
