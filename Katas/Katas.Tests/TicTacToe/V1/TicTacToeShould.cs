using Katas.TicTacToe;

namespace Katas.Tests.TicTacToe.V1;

[TestOf(typeof(TicTacToeGame))]
public class TicTacToeShould
{
    [Test(ExpectedResult = 1)]
    public int? DefineFirstPlayerWinsByDiagonal()
    {
        int?[][] positions = {new int?[] {1, 0, null}, new int?[] {0, 1, null}, new int?[] {null, 0, 1}};

        return TicTacToeGame.WhoWin(positions);
    }

    [Test(ExpectedResult = 1)]
    public int? DefineFirstPlayerWinsByBackDiagonal()
    {
        int?[][] positions = {new int?[] {null, 0, 1}, new int?[] {0, 1, null}, new int?[] {1, 0, null}};

        return TicTacToeGame.WhoWin(positions);
    }

    [Test(ExpectedResult = 1)]
    public int? DefineFirstPlayerWinsByFirstHorizontal()
    {
        int?[][] positions = {new int?[] {1, 1, 1}, new int?[] {0, 0, null}, new int?[] {null, 0, null}};

        return TicTacToeGame.WhoWin(positions);
    }

    [Test(ExpectedResult = 1)]
    public int? DefineFirstPlayerWinsBySecondHorizontal()
    {
        int?[][] positions = {new int?[] {null, null, 0}, new int?[] {1, 1, 1}, new int?[] {0, null, 0}};

        return TicTacToeGame.WhoWin(positions);
    }

    [Test(ExpectedResult = 1)]
    public int? DefineFirstPlayerWinsByThirdHorizontal()
    {
        int?[][] positions = {new int?[] {null, null, 0}, new int?[] {0, null, 0}, new int?[] {1, 1, 1}};

        return TicTacToeGame.WhoWin(positions);
    }

    [Test(ExpectedResult = 1)]
    public int? DefineFirstPlayerWinsByFirstVertical()
    {
        int?[][] positions = {new int?[] {1, 0, null}, new int?[] {1, null, 0}, new int?[] {1, 0, null}};

        return TicTacToeGame.WhoWin(positions);
    }

    [Test(ExpectedResult = 0)]
    public int? DefineSecondPlayerWinsByDiagonal()
    {
        int?[][] positions = {new int?[] {0, 1, null}, new int?[] {1, 0, null}, new int?[] {null, 1, 0}};

        return TicTacToeGame.WhoWin(positions);
    }

    [Test(ExpectedResult = 0)]
    public int? DefineSecondPlayerWinsByBackDiagonal()
    {
        int?[][] positions = {new int?[] {null, 1, 0}, new int?[] {1, 0, null}, new int?[] {0, 1, null}};

        return TicTacToeGame.WhoWin(positions);
    }

    [Test(ExpectedResult = 0)]
    public int? DefineSecondPlayerWinsBySecondHorizontal()
    {
        int?[][] positions = {new int?[] {null, null, 1}, new int?[] {0, 0, 0}, new int?[] {1, 1, null}};

        return TicTacToeGame.WhoWin(positions);
    }

    [Test(ExpectedResult = 0)]
    public int? DefineSecondPlayerWinsByThirdHorizontal()
    {
        int?[][] positions = {new int?[] {null, null, 1}, new int?[] {1, 1, null}, new int?[] {0, 0, 0}};

        return TicTacToeGame.WhoWin(positions);
    }

    [Test(ExpectedResult = 0)]
    public int? DefineSecondPlayerWinsByFirstVertical()
    {
        int?[][] positions = {new int?[] {0, 1, null}, new int?[] {0, null, 1}, new int?[] {0, 1, null}};

        return TicTacToeGame.WhoWin(positions);
    }

    [Test(ExpectedResult = -1)]
    public int? DefineDraw()
    {
        int?[][] positions = {new int?[] {1, 0, 0}, new int?[] {0, 1, 1}, new int?[] {1, 1, 0}};

        return TicTacToeGame.WhoWin(positions);
    }
}