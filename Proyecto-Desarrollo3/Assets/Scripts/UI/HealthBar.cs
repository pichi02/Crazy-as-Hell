using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private CarLife carLife;
    private Image sliderBackground;
    private void Start()
    {
        sliderBackground = slider.GetComponentsInChildren<Image>()[1];
        carLife.OnTakeDamage += SetHeath;
        carLife.OnIncreaseLife += SetHeath;
    }

    public void SetHeath(int health, int maxHealth, bool takeDamage)
    {
        slider.maxValue = maxHealth;
        slider.value = health;
        if (takeDamage)
        {
            StartTakeDamageCoroutine();
        }
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

    IEnumerator TakeDamageCoroutine()
    {
        sliderBackground.color = Color.red;
        yield return new WaitForSeconds(1.5f);
        sliderBackground.color = Color.green;
    }

    private void StartTakeDamageCoroutine()
    {
        StartCoroutine(TakeDamageCoroutine());
    }
}
