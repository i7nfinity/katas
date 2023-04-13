namespace TDDMicroExercises.TurnTicketDispenser;

public class TurnNumberSequence : ITurnNumberSequence
{
    private int _turnNumber;

    public int GetNextTurnNumber()
    {
        return _turnNumber++;
    }
}

public interface ITurnNumberSequence
{
    int GetNextTurnNumber();
}