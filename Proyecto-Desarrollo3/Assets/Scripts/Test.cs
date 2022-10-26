using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Test : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Image cardImage;
    private bool isSelected = false;

    private void Awake()
    {
        cardImage = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        cardImage.color = Color.green;
        isSelected = true;
        transform.localScale *= 2f;
        Debug.Log("click");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        cardImage.color = Color.blue;
        transform.localScale = Vector3.one * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isSelected)
        {
            SetCardDefautlt();
        }
    }

    public void SetCardDefautlt()
    {
        cardImage.color = Color.white;
        transform.localScale = Vector3.one;
        isSelected = false;
    }
}
