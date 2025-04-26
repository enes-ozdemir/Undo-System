using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Stack[] stacks;
    public UndoManager undoManager;
    public Card selectedCard;

    public void OnUndoButtonPressed()
    {
        if (undoManager != null)
        {
            undoManager.Undo();
        }
    }

    private void Update()
    {
        //Shake the card preferebly with dotween
        if (selectedCard != null)
        {
            selectedCard.transform.position = new Vector3(
                selectedCard.transform.position.x + UnityEngine.Random.Range(-1f, 1f),
                selectedCard.transform.position.y + UnityEngine.Random.Range(-1f, 1f),
                selectedCard.transform.position.z
            );
            selectedCard.Selected();
        }
    }
    
    public void SelectCard(Card card)
    {
        Debug.Log("Selected card: " + card.name);
        selectedCard = card;
    }

    public void DeselectCard()
    {
        selectedCard.Deselected();
        selectedCard = null;

    }
}
