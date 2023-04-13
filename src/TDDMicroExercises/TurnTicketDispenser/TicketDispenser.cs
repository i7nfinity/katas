namespace TDDMicroExercises.TurnTicketDispenser;

public class TicketDispenser
{
    private readonly ITurnNumberSequence _turnNumberSequence;

    public TicketDispenser()
    {
        _turnNumberSequence = new TurnNumberSequence();
    }

    public TicketDispenser(ITurnNumberSequence turnNumberSequence)
    {
        _turnNumberSequence = turnNumberSequence;
    }

    public TurnTicket GetTurnTicket()
    {
        var newTurnNumber = _turnNumberSequence.GetNextTurnNumber();
        var newTurnTicket = new TurnTicket(newTurnNumber);

        return newTurnTicket;
    }
}