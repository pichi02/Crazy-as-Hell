using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCooldown : MonoBehaviour
{
    public void EnableCooldown()
    {
        gameObject.SetActive(true);
    }   
    public void DisableCooldown()
    {
        gameObject.SetActive(false);
    }
}
