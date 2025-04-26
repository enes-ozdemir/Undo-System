using System;
using UnityEngine;
using System.Collections.Generic;

public class Stack : MonoBehaviour
{
    public List<Card> cards = new List<Card>();

    private void Start()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.SetParent(transform);
            cards[i].transform.localPosition = new Vector3(0, -50 * i, 0); // Stagger visually
            cards[i].currentStack = this;
        }
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
        card.transform.SetParent(transform);
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.localPosition = new Vector3(0, -50 * i, 0); // Stagger visually
        }
        card.currentStack = this;
    }

    public void RemoveCard(Card card)
    {
        cards.Remove(card);
    }
}
