namespace TDDMicroExercises.TurnTicketDispenser;

public class TicketDispenser
{
    public TurnTicket GetTurnTicket()
    {
        var newTurnNumber = TurnNumberSequence.GetNextTurnNumber();
        var newTurnTicket = new TurnTicket(newTurnNumber);

        return newTurnTicket;
    }
}