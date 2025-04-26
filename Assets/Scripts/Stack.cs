using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Stack : MonoBehaviour, IPointerClickHandler
{
    public List<Card> cards = new List<Card>();
    public List<Card> starterCards = new List<Card>();
    public GameManager gameManager;

    private void Start()
    {
        foreach (var card in starterCards)
        {
            AddCard(card);
        }
    }

    public void AddCard(Card card)
    {
        card.transform.SetParent(transform);
        card.transform.localPosition = Vector3.zero; // Reset before stacking
        card.currentStack = this;
        cards.Add(card);

        RepositionCards();
    }

    public void RemoveCard(Card card)
    {
        cards.Remove(card);
    }
    
    private void RepositionCards()
    {
        for (var i = 0; i < cards.Count; i++)
        {
            cards[i].transform.localPosition = new Vector3(0, -50f * i, 0);
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        // Move selected card here
        Debug.Log("Stack clicked: " + gameObject.name);
        var card = gameManager.selectedCard;
        if (card != null && card.currentStack != this)
        {
            var moveCommand = new MoveCardCommand(card, card.currentStack, this);
            gameManager.undoManager.ExecuteCommand(moveCommand);
            card.currentStack.RemoveCard(card);
            AddCard(card);
            gameManager.DeselectCard();
        }
    }
    

}