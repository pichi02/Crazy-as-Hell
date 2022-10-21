using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsDeck : MonoBehaviour
{

    [SerializeField] private List<ObstacleCard> cards;
    [SerializeField] private List<ObstacleCard> nextCards;
    void Start()
    {

    }

    public List<ObstacleCard> GetDeck()
    {
        return cards;
    }
    public List<ObstacleCard> GetNextCards()
    {
        return nextCards;
    }
    public ObstacleCard GetSelectedCard()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].GetIsClicked())
            {
                return cards[i];
            }
        }
        return null;
    }
}
