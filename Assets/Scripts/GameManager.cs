using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Stack[] stacks;
    public UndoManager undoManager;
    public Card selectedCard;

    private void Update()
    {
        if (selectedCard == null) return;
        selectedCard.transform.position = new Vector3(
            selectedCard.transform.position.x + Random.Range(-1f, 1f),
            selectedCard.transform.position.y + Random.Range(-1f, 1f),
            selectedCard.transform.position.z
        );
        selectedCard.Selected();
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