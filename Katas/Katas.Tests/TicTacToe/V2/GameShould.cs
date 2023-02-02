using Katas.TicTacToe.V2;

namespace Katas.Tests.TicTacToe.V2;

[TestOf(typeof(Game))]
public class GameShould
{
    [Test(ExpectedResult = StepResultKind.Accessed)]
    public StepResultKind DefineXAlwaysGoesFirst()
    {
        var game = new Game();
        var position = new Position(0, 0);

        return game.MakeStep(position, MarkKind.X);
    }

    [Test(ExpectedResult = StepResultKind.Denied)]
    public StepResultKind DefineONeverGoesFirst()
    {
        var game = new Game();
        Position position = Positions.Position00;

        return game.MakeStep(position, MarkKind.O);
    }

    [Test(ExpectedResult = StepResultKind.Denied)]
    public StepResultKind DenyMakingStepsForEmpty()
    {
        var game = new Game();
        Position position = Positions.Position00;

        return game.MakeStep(position, MarkKind.Empty);
    }

    [Test(ExpectedResult = StepResultKind.Accessed)]
    public StepResultKind DefineCorrectOrderAfterX()
    {
        var game = new Game();
        Position position1 = Positions.Position00;
        Position position2 = Positions.Position01;

        game.MakeStep(position1, MarkKind.X);
        StepResultKind result = game.MakeStep(position2, MarkKind.O);

        return result;
    }

    [Test(ExpectedResult = StepResultKind.Accessed)]
    public StepResultKind DefineCorrectOrderAfterO()
    {
        var game = new Game();
        Position position1 = Positions.Position00;
        Position position2 = Positions.Position01;
        Position position3 = Positions.Position02;

        game.MakeStep(position1, MarkKind.X);
        game.MakeStep(position2, MarkKind.O);
        StepResultKind result = game.MakeStep(position3, MarkKind.X);

        return result;
    }

    [Test(ExpectedResult = StepResultKind.Denied)]
    public StepResultKind DenyMakeStepOnPlayedPosition()
    {
        var game = new Game();
        Position position1 = Positions.Position00;
        Position position2 = Positions.Position00;

        game.MakeStep(position1, MarkKind.X);
        StepResultKind result = game.MakeStep(position2, MarkKind.O);

        return result;
    }

    [Test(ExpectedResult = StepResultKind.Won)]
    public StepResultKind DefineXPlayerWonByDiagonal()
    {
        var game = new Game();

        game.MakeStep(Positions.Position00, MarkKind.X);
        game.MakeStep(Positions.Position01, MarkKind.O);
        game.MakeStep(Positions.Position11, MarkKind.X);
        game.MakeStep(Positions.Position12, MarkKind.O);
        StepResultKind result = game.MakeStep(Positions.Position22, MarkKind.X);

        return result;
    }

    [Test(ExpectedResult = StepResultKind.Won)]
    public StepResultKind Define0PlayerWonByBackDiagonal()
    {
        var game = new Game();

        game.MakeStep(Positions.Position00, MarkKind.X);
        game.MakeStep(Positions.Position02, MarkKind.O);
        game.MakeStep(Positions.Position10, MarkKind.X);
        game.MakeStep(Positions.Position11, MarkKind.O);
        game.MakeStep(Positions.Position21, MarkKind.X);
        StepResultKind result = game.MakeStep(Positions.Position20, MarkKind.O);

        return result;
    }

    [Test(ExpectedResult = StepResultKind.Won)]
    public StepResultKind DefineXPlayerWonByLastHorizontal()
    {
        var game = new Game();

        game.MakeStep(Positions.Position20, MarkKind.X);
        game.MakeStep(Positions.Position01, MarkKind.O);
        game.MakeStep(Positions.Position21, MarkKind.X);
        game.MakeStep(Positions.Position12, MarkKind.O);
        StepResultKind result = game.MakeStep(Positions.Position22, MarkKind.X);

        return result;
    }

    [Test(ExpectedResult = StepResultKind.Won)]
    public StepResultKind DefineXPlayerWonByFirstVertical()
    {
        var game = new Game();

        game.MakeStep(Positions.Position10, MarkKind.X);
        game.MakeStep(Positions.Position01, MarkKind.O);
        game.MakeStep(Positions.Position11, MarkKind.X);
        game.MakeStep(Positions.Position22, MarkKind.O);
        StepResultKind result = game.MakeStep(Positions.Position12, MarkKind.X);

        return result;
    }

    [Test(ExpectedResult = StepResultKind.Draw)]
    public StepResultKind DefineIfDraw()
    {
        var game = new Game();

        game.MakeStep(Positions.Position01, MarkKind.X);
        game.MakeStep(Positions.Position00, MarkKind.O);
        game.MakeStep(Positions.Position02, MarkKind.X);
        game.MakeStep(Positions.Position11, MarkKind.O);
        game.MakeStep(Positions.Position10, MarkKind.X);
        game.MakeStep(Positions.Position12, MarkKind.O);
        game.MakeStep(Positions.Position21, MarkKind.X);
        game.MakeStep(Positions.Position20, MarkKind.O);
        StepResultKind result = game.MakeStep(Positions.Position22, MarkKind.X);

        return result;
    }
}