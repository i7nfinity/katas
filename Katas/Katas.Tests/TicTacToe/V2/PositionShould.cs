using Katas.TicTacToe.V2;

namespace Katas.Tests.TicTacToe.V2;

[TestOf(typeof(Position))]
public class PositionShould
{
    [Test(ExpectedResult = true)]
    public bool DefineTwoEqualsPosition()
    {
        var firstPosition = new Position(0, 0);
        var secondPosition = new Position(0, 0);

        return firstPosition.Equals(secondPosition);
    }

    [Test(ExpectedResult = true)]
    public bool DefineTwoNotEqualsPosition()
    {
        var firstPosition = new Position(0, 0);
        var secondPosition = new Position(1, 0);

        return !firstPosition.Equals(secondPosition);
    }
}