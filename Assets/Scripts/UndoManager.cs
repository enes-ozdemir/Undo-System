using UnityEngine;
using System.Collections.Generic;

public class UndoManager : MonoBehaviour
{
    private readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }

    public void Undo()
    {
        if (_commandHistory.Count > 0)
        {
            var lastCommand = _commandHistory.Pop();
            lastCommand.Undo();
        }
    }
}