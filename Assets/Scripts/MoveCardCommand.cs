public class MoveCardCommand : ICommand
{
    private readonly Card _card;
    private readonly Stack _fromStack;
    private readonly Stack _toStack;

    public MoveCardCommand(Card card, Stack from, Stack to)
    {
        _card = card;
        _fromStack = from;
        _toStack = to;
    }

    public void Execute()
    {
        _fromStack.RemoveCard(_card);
        _toStack.AddCard(_card);
    }

    public void Undo()
    {
        _toStack.RemoveCard(_card);
        _fromStack.AddCard(_card);
    }
} 