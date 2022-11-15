using System.Collections.Generic;
using UnityEngine;

public class CardsDeck : MonoBehaviour
{
    [SerializeField] private List<CardUI> cards;
    public int lastSelectedCard;
    CardUI inactiveCard;
    private void Start()
    {
        
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].OnSelectCard += CardsDeck_OnSelectCard;
            cards[i].ID = i;
            cards[i].gameObject.SetActive(false);
        }
        inactiveCard = GetInactiveCard();

    }

    private void CardsDeck_OnSelectCard(int id)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].SetCardDefault();
        }
        cards[id].SetCardSelected();
        lastSelectedCard = id;
    }

    public List<CardUI> GetDeck()
    {
        return cards;
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

    public void EnableCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].gameObject.SetActive(true);
        }
        if (inactiveCard != null)
        {
            inactiveCard.gameObject.SetActive(false);
        }
    }
    public void DisableCards()
    {
        inactiveCard = GetInactiveCard();
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].gameObject.SetActive(false);
        }
    }
}
