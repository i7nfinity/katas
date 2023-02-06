namespace Katas.GameOfLife;

public sealed class Board
{
    private readonly Dictionary<Point, PointState> _board = new();

    public Board(HashSet<Point> points)
    {
        foreach (Point point in points)
        {
            _board.Add(point, PointState.Populated);
        }
    }

    public HashSet<Point> GetPopulatedPointsAfterTick()
    {
        return new HashSet<Point>();
    }
}