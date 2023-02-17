using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    public void InstatiateParticles(Transform t)
    {
        Instantiate(particle, t.position, t.rotation);
    }
}
