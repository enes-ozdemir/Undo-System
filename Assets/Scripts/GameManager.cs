using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Stack[] stacks;
    public UndoManager undoManager;

    public void OnUndoButtonPressed()
    {
        if (undoManager != null)
        {
            undoManager.Undo();
        }
    }
}
