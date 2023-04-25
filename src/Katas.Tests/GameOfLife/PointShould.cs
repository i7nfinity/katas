using System.Collections.Generic;
using Katas.GameOfLife;

namespace Katas.Tests.GameOfLife;

[TestFixture(TestOf = typeof(Point))]
public class PointShould
{
    [Test]
    public void DefineAllNeighbors()
    {
        var position = new Point(2, 2);
        var expected = new SortedSet<Point>
        {
            new(2, 1),
            new(2, 3),
            new(1, 2),
            new(3, 2),
            new(3, 1),
            new(3, 3),
            new(1, 1),
            new(1, 3)
        };

        SortedSet<Point> actual = position.GetNeighbors();

        Assert.That(actual, Is.EqualTo(expected));
    }
}