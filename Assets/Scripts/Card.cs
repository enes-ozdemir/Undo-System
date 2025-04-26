using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Stack currentStack;
    public GameManager gameManager;
    public UndoManager undoManager;
    private Vector3 _startPosition;
    private Transform _originalParent;

    private bool _isDragValid;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (currentStack == null || currentStack.cards.Count == 0 || currentStack.cards[^1] != this)
        {
            Debug.Log("You can only drag the last card of the stack.");
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
        if (!_isDragValid)
            return;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_isDragValid)
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
}