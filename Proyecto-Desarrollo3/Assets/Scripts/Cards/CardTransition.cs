using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTransition : MonoBehaviour
{

    private void OnMouseOver()
    {
        transform.localScale *= 2;
        Debug.Log("entro a la transicion");
    }
}
