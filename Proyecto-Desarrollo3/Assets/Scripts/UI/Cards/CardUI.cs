using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Image cardImage;
    private bool isSelected = false;
    public event Action<int> OnSelectCard;

    [SerializeField] private GameObject prefab;

    private int id;
    public int ID
    {
        get => id;
        set => id = value;
    }

    private void Awake()
    {
        cardImage = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnSelectCard?.Invoke(ID);
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
    public void SetCardSelected()
    {
        cardImage.color = Color.green;
        isSelected = true;
        transform.localScale *= 1.4f;
        Debug.Log("click");
    }

    public GameObject GetPrefab()
    {
        return prefab;
    }
    public bool GetIsSelected()
    {
        return isSelected;
    }


}







