namespace Katas.TicTacToe.V2;

public class Board
{
    private readonly MarkKind[][] _board =
    {
        new[] {MarkKind.Empty, MarkKind.Empty, MarkKind.Empty},
        new[] {MarkKind.Empty, MarkKind.Empty, MarkKind.Empty},
        new[] {MarkKind.Empty, MarkKind.Empty, MarkKind.Empty}
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
        var x = position.X;
        var y = position.Y;
        if (_board[x][y] != MarkKind.Empty)
        {
            return false;
        }

        _board[x][y] = mark;
        return true;
    }

    public bool IsBusyAllPositions()
    {
        return _board.SelectMany(b => b).All(b => b != MarkKind.Empty);
    }

    public bool IsBusyAtLeastOneWinPositionsInLine(MarkKind mark)
    {
        return _winPositionsLines.Any(line => IsBusyAllLine(line, mark));
    }

    private bool IsBusyAllLine(IEnumerable<Position> line, MarkKind mark)
    {
        return line.All(position => _board[position.X][position.Y] == mark);
    }
}