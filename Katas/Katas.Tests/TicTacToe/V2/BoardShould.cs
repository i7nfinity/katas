using Katas.TicTacToe.V2;

namespace Katas.Tests.TicTacToe.V2;

[TestOf(typeof(Board))]
public class BoardShould
{
    [Test(ExpectedResult = ValidatePositionResult.Success)]
    public ValidatePositionResult AllowSettingFreePosition()
    {
        var board = new Board();

        return board.ValidatePosition(Positions.Position00);
    }

    [Test(ExpectedResult = ValidatePositionResult.Busy)]
    public ValidatePositionResult DisallowSettingBusyPosition()
    {
        var board = new Board();

        board.SetStep(Positions.Position00, MarkKind.X);

        return board.ValidatePosition(Positions.Position00);
    }

    [Test(ExpectedResult = ValidatePositionResult.Invalid)]
    public ValidatePositionResult DisallowSettingInvalidPosition()
    {
        var board = new Board();

        return board.ValidatePosition(new Position(int.MaxValue, int.MaxValue));
    }

    [TestCase(MarkKind.X, 0, ExpectedResult = true)]
    [TestCase(MarkKind.X, 1, ExpectedResult = true)]
    [TestCase(MarkKind.O, 0, ExpectedResult = true)]
    [TestCase(MarkKind.O, 1, ExpectedResult = true)]
    public bool DefineIfOneKindTakeAllBackDiagonallyPlaces(MarkKind kind, int line)
    {
        var board = new Board();

        foreach (Position position in PositionSets.WinDiagonals[line])
        {
            board.SetStep(position, kind);
        }

        return board.IsBusyAtLeastOneWinPositionsInLine(kind);
    }

    [TestCase(MarkKind.X, 0, ExpectedResult = true)]
    [TestCase(MarkKind.X, 1, ExpectedResult = true)]
    [TestCase(MarkKind.X, 2, ExpectedResult = true)]
    [TestCase(MarkKind.O, 0, ExpectedResult = true)]
    [TestCase(MarkKind.O, 1, ExpectedResult = true)]
    [TestCase(MarkKind.O, 2, ExpectedResult = true)]
    public bool DefineIfChosenKindTakeAllPlacesInHorizontalLine(MarkKind kind, int line)
    {
        var board = new Board();

        foreach (Position position in PositionSets.WinHorizontals[line])
        {
            board.SetStep(position, kind);
        }

        return board.IsBusyAtLeastOneWinPositionsInLine(kind);
    }

    [TestCase(MarkKind.X, 0, ExpectedResult = true)]
    [TestCase(MarkKind.X, 1, ExpectedResult = true)]
    [TestCase(MarkKind.X, 2, ExpectedResult = true)]
    [TestCase(MarkKind.O, 0, ExpectedResult = true)]
    [TestCase(MarkKind.O, 1, ExpectedResult = true)]
    [TestCase(MarkKind.O, 2, ExpectedResult = true)]
    public bool DefineIfChosenKindTakeAllPlacesInVerticalLine(MarkKind kind, int line)
    {
        var board = new Board();

        foreach (Position position in PositionSets.WinVerticals[line])
        {
            board.SetStep(position, kind);
        }

        return board.IsBusyAtLeastOneWinPositionsInLine(kind);
    }

    [Test(ExpectedResult = false)]
    public bool DefineIfBusyNotAllPositions()
    {
        var board = new Board();

        return board.IsBusyAllPositions();
    }

    [TestCase(MarkKind.X, ExpectedResult = true)]
    public bool DefineIfBusyAllPositions(MarkKind kind)
    {
        var board = new Board();

        foreach (Position position in PositionSets.AllPositions)
        {
            board.SetStep(position, kind);
        }

        return board.IsBusyAllPositions();
    }
}