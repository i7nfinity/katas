namespace Katas.TicTacToe;

/// <summary>
///     Tic Tac Toe rules
///     <list type="bullet">
///         <item>
///             <term>X always goes first.</term>
///         </item>
///         <item>
///             <term>Players alternate placing X’s and O’s on the board.</term>
///         </item>
///         <item>
///             <term>Players cannot play on a played position.</term>
///         </item>
///         <item>
///             <term>A player with three X’s or O’s in a row (horizontally, vertically, diagonally) wins.</term>
///         </item>
///         <item>
///             <term>If all nine squares are filled and neither player achieves three in a row, the game is a draw.</term>
///         </item>
///     </list>
/// </summary>
public static class TicTacToeGame
{
    /// <summary>
    ///     Define who wins
    /// </summary>
    /// <returns>1 - first player win, 0 - second player win, -1 - a draw</returns>
    public static int? WhoWin(int?[][] gamePositions)
    {
        if (IsWin(gamePositions, 0))
        {
            return 0;
        }

        if (IsWin(gamePositions, 1))
        {
            return 1;
        }

        if (IsDraw(gamePositions))
        {
            return -1;
        }

        return null;
    }

    private static bool IsDraw(int?[][] gamePositions)
    {
        for (var i = 0; i <= 2; i++)
        for (var j = 0; j <= 2; j++)
        {
            if (gamePositions[i][j] is null)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsWin(int?[][] gamePositions, int playerSymbol)
    {
        return IsWinByDiagonal(gamePositions, false, playerSymbol) ||
               IsWinByDiagonal(gamePositions, true, playerSymbol) ||
               IsWinByHorizontal(gamePositions, 0, playerSymbol) ||
               IsWinByHorizontal(gamePositions, 1, playerSymbol) ||
               IsWinByHorizontal(gamePositions, 2, playerSymbol) ||
               IsWinByVertical(gamePositions, 0, playerSymbol) ||
               IsWinByVertical(gamePositions, 1, playerSymbol) ||
               IsWinByVertical(gamePositions, 2, playerSymbol);
    }

    private static bool IsWinByDiagonal(int?[][] gamePositions, bool isBackDiagonal, int playerSymbol)
    {
        var result = gamePositions[1][1] == playerSymbol;

        if (isBackDiagonal)
        {
            result = result && gamePositions[0][2] == playerSymbol && gamePositions[2][0] == playerSymbol;
        }
        else
        {
            result = result && gamePositions[0][0] == playerSymbol && gamePositions[2][2] == playerSymbol;
        }

        return result;
    }

    private static bool IsWinByHorizontal(int?[][] gamePositions, int horizontalPosition, int playerSymbol)
    {
        var result = gamePositions[horizontalPosition][0] == playerSymbol;
        for (var j = 1; j <= 2; j++)
        {
            result = result && gamePositions[horizontalPosition][j] == playerSymbol;
        }

        return result;
    }

    private static bool IsWinByVertical(int?[][] gamePositions, int verticalPosition, int playerSymbol)
    {
        var result = gamePositions[0][verticalPosition] == playerSymbol;
        for (var j = 1; j <= 2; j++)
        {
            result = result && gamePositions[j][verticalPosition] == playerSymbol;
        }

        return result;
    }
}