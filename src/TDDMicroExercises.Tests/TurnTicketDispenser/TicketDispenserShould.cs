namespace TDDMicroExercises.TurnTicketDispenser;

public class TicketDispenserShould
{
    [Fact]
    public void ReturnZeroTicketNumberForFirstClient()
    {
        var dispenser = new TicketDispenser();

        TurnTicket ticket = dispenser.GetTurnTicket();

        Assert.Equal(0, ticket.TurnNumber);
    }

    [Fact]
    public void ReturnThirdTicketNumberAfterPreviousSecondTicket()
    {
        var turnNumberSequence = new TurnNumberSequenceSpy(2);
        var dispenser = new TicketDispenser(turnNumberSequence);

        dispenser.GetTurnTicket();
        TurnTicket nextTicket = dispenser.GetTurnTicket();

        Assert.Equal(3, nextTicket.TurnNumber);
    }

    [Fact]
    public void ReturnDifferentTicketFromDifferentDispenser()
    {
        var turnNumberSequence = new TurnNumberSequenceSpy(1);
        var firstDispenser = new TicketDispenser(turnNumberSequence);
        var secondDispenser = new TicketDispenser(turnNumberSequence);

        TurnTicket firstTicket = firstDispenser.GetTurnTicket();
        TurnTicket secondTicket = secondDispenser.GetTurnTicket();

        Assert.NotEqual(firstTicket.TurnNumber, secondTicket.TurnNumber);
    }
}