public class MoveCardCommand : ICommand
{
    private Card card;
    private Stack fromStack;
    private Stack toStack;

    public MoveCardCommand(Card card, Stack from, Stack to)
    {
        this.card = card;
        fromStack = from;
        toStack = to;
    }

    public void Execute()
    {
        fromStack.RemoveCard(card);
        toStack.AddCard(card);
    }

    public void Undo()
    {
        toStack.RemoveCard(card);
        fromStack.AddCard(card);
    }
} 