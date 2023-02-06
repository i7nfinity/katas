using System.Collections.Generic;
using Katas.GameOfLife;

namespace Katas.Tests.GameOfLife;

[TestFixture(TestOf = typeof(Board))]
public class BoardShould
{
    [Test]
    public void DefineCellDiesWithoutLiveNeighbors()
    {
        var points = new HashSet<Point> {new(2, 2)};
        var board = new Board(points);

        HashSet<Point> actual = board.GetPopulatedPointsAfterTick();

        Assert.That(actual, Is.Empty);
    }

    [TestCase(2, 3)]
    [TestCase(2, 1)]
    [TestCase(1, 1)]
    [TestCase(1, 2)]
    [TestCase(1, 3)]
    [TestCase(3, 1)]
    [TestCase(3, 2)]
    [TestCase(3, 3)]
    public void DefineCellDiesWithOneLiveNeighbor(int x, int y)
    {
        var points = new HashSet<Point> {new(2, 2), new(x, y)};
        var board = new Board(points);

        HashSet<Point> actual = board.GetPopulatedPointsAfterTick();

        Assert.That(actual, Is.Empty);
    }
}