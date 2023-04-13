namespace TDDMicroExercises.TurnTicketDispenser;

public class TurnNumberSequenceSpy : ITurnNumberSequence
{
    private readonly int _turnNumber;
    private int _counter;

    public TurnNumberSequenceSpy(int turnNumber)
    {
        _turnNumber = turnNumber;
    }

    public int GetNextTurnNumber()
    {
        return _turnNumber + _counter++;
    }
}