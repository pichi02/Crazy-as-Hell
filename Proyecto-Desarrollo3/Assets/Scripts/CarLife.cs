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

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.CompareTag("Obstacle"))
    //    {
    //        TakeDamage(20);
    //    }
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //TakeDamage(5);
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 5;

        healthBar.SetHeath(currentHealth);
    }
}
