namespace Katas.TicTacToe.V2;

public class Game
{
    private readonly Board _board = new();
    private int _stepCount = 1;

    public StepResultKind MakeStep(Position position, MarkKind mark)
    {
        if (mark == MarkKind.Empty)
        {
            return StepResultKind.Denied;
        }

        if ((_stepCount % 2 == 1 && mark == MarkKind.O) ||
            (_stepCount % 2 == 0 && mark == MarkKind.X))
        {
            return StepResultKind.Denied;
        }

        if (!_board.TrySetPosition(position, mark))
        {
            return StepResultKind.Denied;
        }

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
}