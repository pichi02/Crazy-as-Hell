using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private ObstacleSpawner obstacleSpawner;

    void Start()
    {
        obstacleSpawner.OnSetCooldown += SetCooldown;
    }

    public void SetCooldown(float cooldown)
    {
        slider.value = cooldown;
    }

    private void OnDestroy()
    {
        obstacleSpawner.OnSetCooldown -= SetCooldown;
    }
}
