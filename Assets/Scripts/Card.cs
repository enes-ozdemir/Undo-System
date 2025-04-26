using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerClickHandler
{
    public Stack currentStack;
    public GameManager gameManager;
    public UndoManager undoManager;
    private Vector3 _startPosition;
    private Transform _originalParent;

    private bool _isDragValid;
    private bool _isClicked;

    public Image cardImage;

    private void Awake()
    {
        cardImage = GetComponent<Image>();
    }

    public void Selected() => cardImage.color = Color.green;

    public void Deselected() => cardImage.color = Color.white;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (currentStack == null || currentStack.cards.Count == 0 || currentStack.cards[^1] != this || _isClicked)
        {
            Debug.Log("You can only drag the last unClicked card of the stack.");
            _isDragValid = false;
            return;
        }

        _isDragValid = true;
        _startPosition = transform.position;
        _originalParent = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_isDragValid|| _isClicked)
            return;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_isDragValid || _isClicked)
            return;

        Stack targetStack = null;
        foreach (var stack in gameManager.stacks)
        {
            foreach (Transform child in stack.transform)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(
                        child.GetComponent<RectTransform>(), Input.mousePosition))
                {
                    targetStack = stack;
                    break;
                }
            }

            if (targetStack != null)
                break;
        }

        if (targetStack != null && targetStack != currentStack)
        {
            var moveCommand = new MoveCardCommand(this, currentStack, targetStack);
            undoManager.ExecuteCommand(moveCommand);
            currentStack = targetStack;
        }
        else
        {
            transform.position = _startPosition;
            transform.SetParent(_originalParent);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentStack == null || currentStack.cards.Count == 0 || currentStack.cards[^1] != this)
        {
            Debug.Log("You can only click the last card of the stack.");
            return;
        }

        if (gameManager.selectedCard == null)
        {
            gameManager.SelectCard(this);
        }
        else if (gameManager.selectedCard != this)
        {
            // Move the selected card to this card's stack
            var selected = gameManager.selectedCard;
            var moveCommand = new MoveCardCommand(selected, selected.currentStack, currentStack);
            gameManager.undoManager.ExecuteCommand(moveCommand);
            gameManager.DeselectCard();
        }
        else
        {
            gameManager.DeselectCard();
        }
    }

}