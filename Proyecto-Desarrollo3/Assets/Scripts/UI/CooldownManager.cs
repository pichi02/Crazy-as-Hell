using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class CooldownManager : MonoBehaviour
{
    [SerializeField] private ObstacleSpawner obstacleSpawner;
    [SerializeField] private List<Image> obstacleImages;

    void Start()
    {
        obstacleSpawner.OnSetCooldown += SetCooldown;
    }

    public void SetCooldown(float cooldown)
    {
        for (int i = 0; i < obstacleImages.Count; i++)
        {
            obstacleImages[i].fillAmount = cooldown / 5;
        }
    }

    private void OnDestroy()
    {
        obstacleSpawner.OnSetCooldown -= SetCooldown;
    }
}
