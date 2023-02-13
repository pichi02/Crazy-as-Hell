using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotation : MonoBehaviour
{
    [SerializeField] private Vector3 rotation;
    void FixedUpdate()
    {
        transform.Rotate(rotation);
    }
}
