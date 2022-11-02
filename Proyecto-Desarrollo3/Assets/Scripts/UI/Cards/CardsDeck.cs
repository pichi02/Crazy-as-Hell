using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsDeck : MonoBehaviour
{
    [SerializeField] private List<CardUI> cards;
    [SerializeField] private List<CardUI> nextCards;
    public int lastSelectedCard;
    private void Start()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].OnSelectCard += CardsDeck_OnSelectCard;
            cards[i].ID = i;
        }
        cards[0].gameObject.SetActive(false);
    }

    private void CardsDeck_OnSelectCard(int id)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].SetCardDefautlt();
        }
        cards[id].SetCardSelected();
        lastSelectedCard = id;
    }

    public List<CardUI> GetDeck()
    {
        return cards;
    }
    public List<CardUI> GetNextCards()
    {
        return nextCards;
    }
    public CardUI GetSelectedCard()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].GetIsSelected())
            {
                return cards[i];
            }
        }
        return null;
    }

    public CardUI GetInactiveCard()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (!cards[i].gameObject.activeInHierarchy)
            {
                return cards[i];
            }
        }
        return null;
    }
}
