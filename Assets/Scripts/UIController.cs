using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private UndoManager undoManager;
    [SerializeField] private Button undoButton;

    private void OnEnable() => undoButton.onClick.AddListener(OnUndoButtonPressed);

    private void OnDisable() => undoButton.onClick.RemoveListener(OnUndoButtonPressed);

    private void OnUndoButtonPressed() => undoManager.Undo();
}