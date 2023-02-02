using Katas.TicTacToe.V2;

namespace Katas.Tests.TicTacToe.V2;

[TestOf(typeof(Board))]
public class BoardShould
{
    [TestCase(MarkKind.X, ExpectedResult = true)]
    [TestCase(MarkKind.O, ExpectedResult = true)]
    public bool AllowSettingFreePosition(MarkKind kind)
    {
        var board = new Board();

        return board.TrySetPosition(Positions.Position00, kind);
    }

    [TestCase(MarkKind.X, ExpectedResult = false)]
    [TestCase(MarkKind.O, ExpectedResult = false)]
    public bool DisallowSettingBusyPosition(MarkKind kind)
    {
        var board = new Board();

        board.TrySetPosition(Positions.Position00, kind);

        return board.TrySetPosition(Positions.Position00, kind);
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
            board.TrySetPosition(position, kind);
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
            board.TrySetPosition(position, kind);
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
            board.TrySetPosition(position, kind);
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
            board.TrySetPosition(position, kind);
        }

        return board.IsBusyAllPositions();
    }
}