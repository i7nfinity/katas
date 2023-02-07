using Katas.TicTacToe.V2;

namespace Katas.Tests.TicTacToe.V2;

//TODO: All classes must have state
internal static class PositionSets
{
    public static readonly Position[] AllPositions =
    {
        Positions.Position00, Positions.Position01, Positions.Position02, Positions.Position10,
        Positions.Position11, Positions.Position12, Positions.Position20, Positions.Position21, Positions.Position22
    };

    public static readonly Position[][] WinDiagonals =
    {
        new[] {Positions.Position00, Positions.Position11, Positions.Position22},
        new[] {Positions.Position02, Positions.Position11, Positions.Position20}
    };

    public static readonly Position[][] WinHorizontals =
    {
        new[] {Positions.Position00, Positions.Position01, Positions.Position02},
        new[] {Positions.Position10, Positions.Position11, Positions.Position12},
        new[] {Positions.Position20, Positions.Position21, Positions.Position22}
    };

    public static readonly Position[][] WinVerticals =
    {
        new[] {Positions.Position00, Positions.Position01, Positions.Position02},
        new[] {Positions.Position10, Positions.Position11, Positions.Position12},
        new[] {Positions.Position20, Positions.Position21, Positions.Position22}
    };
}