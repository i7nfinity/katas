namespace Katas.GameOfLife;

/// <summary>
///     The universe of the Game of Life is an infinite, two-dimensional orthogonal grid of square cells,
///     each of which is in one of two possible states: alive or dead (or populated and unpopulated, respectively).
///     Every cell interacts with its eight neighbors, which are the cells that are horizontally, vertically or
///     diagonally adjacent. At each step in time, the following transitions occur:
///     <list type="bullet">
///         <item>
///             <term>Any live cell with fewer than two live neighbors dies, as if by under population.</term>
///         </item>
///         <item>
///             <term>Any live cell with two or three live neighbors lives on to the next generation.</term>
///         </item>
///         <item>
///             <term>Any live cell with more than three live neighbors dies, as if by overpopulation.</term>
///         </item>
///         <item>
///             <term>Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.</term>
///         </item>
///     </list>
///     The initial pattern constitutes the seed of the system.
///     The first generation is created by applying the above rules simultaneously to every cell in the seed; births and
///     deaths occur simultaneously, and the discrete moment at which this happens is sometimes called a tick. Each
///     generation is a pure function of the preceding one.
///     The rules continue to be applied repeatedly to create further generations
/// </summary>
public sealed class Board
{
    private readonly Dictionary<Point, PointState> _board = new();

    public Board(ISet<Point> points)
    {
        foreach (Point point in points)
        {
            _board.Add(point, PointState.Populated);
        }
    }

    public ISet<Point> GetPopulatedPointsAfterTick()
    {
        foreach (Point point in _board.Keys)
        {
            PointState state = DefinePointState(point);
            if (state == PointState.Unpopulated)
            {
                _board.Remove(point);
            }
        }

        return _board.Keys.ToHashSet();
    }

    private PointState DefinePointState(Point cell)
    {
        SortedSet<Point> neighbors = cell.GetNeighbors();
        var countLiveNeighbors = neighbors.Count(neighbor => _board.ContainsKey(neighbor));

        if (countLiveNeighbors is < 2 or > 3)
        {
            return PointState.Unpopulated;
        }

        return PointState.Populated;
    }
}