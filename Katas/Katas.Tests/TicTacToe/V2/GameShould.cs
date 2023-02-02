using Katas.TicTacToe.V2;

namespace Katas.Tests.TicTacToe.V2;

[TestOf(typeof(Game))]
public class GameShould
{
    [Test(ExpectedResult = StepResultKind.Accessed)]
    public StepResultKind DefineXAlwaysGoesFirst()
    {
        var game = new Game();

        return game.TryMakeStep(Positions.Position00, MarkKind.X);
    }

    [Test(ExpectedResult = StepResultKind.InvalidOrder)]
    public StepResultKind DefineONeverGoesFirst()
    {
        var game = new Game();

        return game.TryMakeStep(Positions.Position00, MarkKind.O);
    }

    [Test(ExpectedResult = StepResultKind.InvalidOrder)]
    public StepResultKind DefineXNeverGoesInsteadO()
    {
        var game = new Game();

        game.TryMakeStep(Positions.Position00, MarkKind.X);

        return game.TryMakeStep(Positions.Position01, MarkKind.X);
    }

    [Test(ExpectedResult = StepResultKind.InvalidOrder)]
    public StepResultKind DenyMakingStepsForEmpty()
    {
        var game = new Game();

        return game.TryMakeStep(Positions.Position00, MarkKind.Empty);
    }

    [Test(ExpectedResult = StepResultKind.Accessed)]
    public StepResultKind DefineCorrectOrderAfterX()
    {
        var game = new Game();
        Position position1 = Positions.Position00;
        Position position2 = Positions.Position01;

        game.TryMakeStep(position1, MarkKind.X);
        StepResultKind result = game.TryMakeStep(position2, MarkKind.O);

        return result;
    }

    [Test(ExpectedResult = StepResultKind.Accessed)]
    public StepResultKind DefineCorrectOrderAfterO()
    {
        var game = new Game();
        Position position1 = Positions.Position00;
        Position position2 = Positions.Position01;
        Position position3 = Positions.Position02;

        game.TryMakeStep(position1, MarkKind.X);
        game.TryMakeStep(position2, MarkKind.O);
        StepResultKind result = game.TryMakeStep(position3, MarkKind.X);

        return result;
    }

    [Test(ExpectedResult = StepResultKind.BusyPosition)]
    public StepResultKind DenyMakeStepOnPlayedPosition()
    {
        var game = new Game();
        Position position1 = Positions.Position00;
        Position position2 = Positions.Position00;

        game.TryMakeStep(position1, MarkKind.X);
        StepResultKind result = game.TryMakeStep(position2, MarkKind.O);

        return result;
    }

    [Test(ExpectedResult = StepResultKind.InvalidPosition)]
    public StepResultKind DenyMakeStepWithInvalidPosition()
    {
        var game = new Game();
        var invalidPosition = new Position(int.MaxValue, int.MaxValue);

        return game.TryMakeStep(invalidPosition, MarkKind.X);
    }

    [Test(ExpectedResult = StepResultKind.Won)]
    public StepResultKind DefineXPlayerWonByDiagonal()
    {
        var game = new Game();

        game.TryMakeStep(Positions.Position00, MarkKind.X);
        game.TryMakeStep(Positions.Position01, MarkKind.O);
        game.TryMakeStep(Positions.Position11, MarkKind.X);
        game.TryMakeStep(Positions.Position12, MarkKind.O);
        StepResultKind result = game.TryMakeStep(Positions.Position22, MarkKind.X);

        return result;
    }

    [Test(ExpectedResult = StepResultKind.Won)]
    public StepResultKind Define0PlayerWonByBackDiagonal()
    {
        var game = new Game();

        game.TryMakeStep(Positions.Position00, MarkKind.X);
        game.TryMakeStep(Positions.Position02, MarkKind.O);
        game.TryMakeStep(Positions.Position10, MarkKind.X);
        game.TryMakeStep(Positions.Position11, MarkKind.O);
        game.TryMakeStep(Positions.Position21, MarkKind.X);
        StepResultKind result = game.TryMakeStep(Positions.Position20, MarkKind.O);

        return result;
    }

    [Test(ExpectedResult = StepResultKind.Won)]
    public StepResultKind DefineXPlayerWonByLastHorizontal()
    {
        var game = new Game();

        game.TryMakeStep(Positions.Position20, MarkKind.X);
        game.TryMakeStep(Positions.Position01, MarkKind.O);
        game.TryMakeStep(Positions.Position21, MarkKind.X);
        game.TryMakeStep(Positions.Position12, MarkKind.O);
        StepResultKind result = game.TryMakeStep(Positions.Position22, MarkKind.X);

        return result;
    }

    [Test(ExpectedResult = StepResultKind.Won)]
    public StepResultKind DefineXPlayerWonByFirstVertical()
    {
        var game = new Game();

        game.TryMakeStep(Positions.Position10, MarkKind.X);
        game.TryMakeStep(Positions.Position01, MarkKind.O);
        game.TryMakeStep(Positions.Position11, MarkKind.X);
        game.TryMakeStep(Positions.Position22, MarkKind.O);
        StepResultKind result = game.TryMakeStep(Positions.Position12, MarkKind.X);

        return result;
    }

    [Test(ExpectedResult = StepResultKind.Draw)]
    public StepResultKind DefineIfDraw()
    {
        var game = new Game();

        game.TryMakeStep(Positions.Position01, MarkKind.X);
        game.TryMakeStep(Positions.Position00, MarkKind.O);
        game.TryMakeStep(Positions.Position02, MarkKind.X);
        game.TryMakeStep(Positions.Position11, MarkKind.O);
        game.TryMakeStep(Positions.Position10, MarkKind.X);
        game.TryMakeStep(Positions.Position12, MarkKind.O);
        game.TryMakeStep(Positions.Position21, MarkKind.X);
        game.TryMakeStep(Positions.Position20, MarkKind.O);
        StepResultKind result = game.TryMakeStep(Positions.Position22, MarkKind.X);

        return result;
    }
}