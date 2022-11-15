using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Image cardImage;
    private bool isSelected = false;
    public event Action<int> OnSelectCard;

    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject preVisualize;

    private int id;
    public int ID
    {
        get => id;
        set => id = value;
    }

    private void Awake()
    {
        cardImage = GetComponent<Image>();
        SetCardDefault();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnSelectCard?.Invoke(ID);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        cardImage.color = Color.grey;
        transform.localScale = Vector3.one * 1.1f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isSelected)
        {
            SetCardDefault();
        }
    }

    public void SetCardDefault()
    {
        cardImage.color = Color.white;
        transform.localScale = Vector3.one;
        isSelected = false;
    }
    public void SetCardSelected()
    {
        isSelected = true;
        transform.localScale *= 1.2f;
        Debug.Log("click");
    }

    public GameObject GetPrefab()
    {
        return prefab;
    }
    public GameObject GetPreVisualize()
    {
        return preVisualize;
    }
    public bool GetIsSelected()
    {
        return isSelected;
    }

}







