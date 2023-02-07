namespace Katas.GameOfLife;

public readonly record struct Point : IComparable<Point>
{
    private readonly int _x;
    private readonly int _y;

    public Point(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public int CompareTo(Point other)
    {
        var xComparison = _x.CompareTo(other._x);
        return xComparison != 0 ? xComparison : _y.CompareTo(other._y);
    }

    public SortedSet<Point> GetNeighbors()
    {
        var set = new SortedSet<Point>
        {
            new(_x, _y - 1), //Left
            new(_x, _y + 1), //Right
            new(_x + 1, _y), //Bottom
            new(_x + 1, _y - 1), //LeftBottom
            new(_x + 1, _y + 1), //RightBottom
            new(_x - 1, _y), //Top
            new(_x - 1, _y - 1), //LeftTop
            new(_x - 1, _y + 1) //RightTop
        };
        return set;
    }
}