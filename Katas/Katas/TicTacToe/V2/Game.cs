namespace Katas.TicTacToe.V2;

public sealed class Game
{
    private readonly Board _board = new();
    private int _stepCount = 1;

    //TODO: Keep all entities small: 5 lines per method
    public StepResultKind TryMakeStep(Position position, MarkKind mark)
    {
        if (IsInvalidOrder(mark))
        {
            return StepResultKind.InvalidOrder;
        }

        ValidatePositionResult validatePositionResult = _board.ValidatePosition(position);
        switch (validatePositionResult)
        {
            case ValidatePositionResult.Busy:
                return StepResultKind.BusyPosition;
            case ValidatePositionResult.Invalid:
                return StepResultKind.InvalidPosition;
            case ValidatePositionResult.Success:
            default:
                break;
        }

        _board.SetStep(position, mark);

        if (_board.IsBusyAllPositions())
        {
            return StepResultKind.Draw;
        }

        if (_board.IsBusyAtLeastOneWinPositionsInLine(mark))
        {
            return StepResultKind.Won;
        }

        _stepCount++;
        return StepResultKind.Accessed;
    }

    private bool IsInvalidOrder(MarkKind mark)
    {
        return mark == MarkKind.Empty || (_stepCount % 2 == 1 && mark == MarkKind.O)
                                      || (_stepCount % 2 == 0 && mark == MarkKind.X);
    }
}