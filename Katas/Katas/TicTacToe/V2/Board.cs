namespace Katas.TicTacToe.V2;

public class Board
{
    private readonly Dictionary<Position, MarkKind> _board = new()
    {
        {Positions.Position00, MarkKind.Empty},
        {Positions.Position01, MarkKind.Empty},
        {Positions.Position02, MarkKind.Empty},
        {Positions.Position10, MarkKind.Empty},
        {Positions.Position11, MarkKind.Empty},
        {Positions.Position12, MarkKind.Empty},
        {Positions.Position20, MarkKind.Empty},
        {Positions.Position21, MarkKind.Empty},
        {Positions.Position22, MarkKind.Empty}
    };

    private readonly Position[][] _winPositionsLines =
    {
        //diagonals
        new[] {Positions.Position00, Positions.Position11, Positions.Position22},
        new[] {Positions.Position02, Positions.Position11, Positions.Position20},

        //horizontals
        new[] {Positions.Position00, Positions.Position01, Positions.Position02},
        new[] {Positions.Position10, Positions.Position11, Positions.Position12},
        new[] {Positions.Position20, Positions.Position21, Positions.Position22},

        //verticals
        new[] {Positions.Position00, Positions.Position10, Positions.Position20},
        new[] {Positions.Position01, Positions.Position11, Positions.Position21},
        new[] {Positions.Position02, Positions.Position12, Positions.Position22}
    };

    public bool TrySetPosition(Position position, MarkKind mark)
    {
        //TODO: check position
        if (_board[position] != MarkKind.Empty)
        {
            return false;
        }

        _board[position] = mark;
        return true;
    }

    public bool IsBusyAllPositions()
    {
        return _board.Values.All(b => b != MarkKind.Empty);
    }

    public bool IsBusyAtLeastOneWinPositionsInLine(MarkKind mark)
    {
        return _winPositionsLines.Any(line => IsBusyAllLine(line, mark));
    }

    private bool IsBusyAllLine(IEnumerable<Position> line, MarkKind mark)
    {
        return line.All(position => _board[position] == mark);
    }
}