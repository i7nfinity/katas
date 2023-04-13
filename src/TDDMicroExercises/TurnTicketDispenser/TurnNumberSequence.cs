namespace TDDMicroExercises.TurnTicketDispenser;

public static class TurnNumberSequence
{
    private static int _turnNumber;

    public static int GetNextTurnNumber()
    {
        return _turnNumber++;
    }
}