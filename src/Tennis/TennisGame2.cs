namespace Tennis;

public class TennisGame2 : ITennisGame
{
    private int _firstPlayerPoint;
    private int _secondPlayerPoint;

    public string GetScore()
    {
        if (IsSamePointsLessThanThree())
        {
            return GetScoreForSamePointsLessThanThree();
        }
        if (IsSamePointsGreaterThanTwo())
        {
            return "Deuce";
        }

        if (IsWinOnePoint(_firstPlayerPoint, _secondPlayerPoint))
        {
            return "Win for player1";
        }

        if (IsWinOnePoint(_secondPlayerPoint, _firstPlayerPoint))
        {
            return "Win for player2";
        }

        if (IsOnePointLessThanFourAndGreaterThanOtherPoint(_firstPlayerPoint, _secondPlayerPoint) ||
            IsOnePointLessThanFourAndGreaterThanOtherPoint(_secondPlayerPoint,_firstPlayerPoint) ||
            IsOnePointGreaterThanZeroAndOtherPointEqualsZero(_firstPlayerPoint, _secondPlayerPoint) ||
            IsOnePointGreaterThanZeroAndOtherPointEqualsZero(_secondPlayerPoint, _firstPlayerPoint))
        {
            return GetScorePart(_firstPlayerPoint) + "-" + GetScorePart(_secondPlayerPoint);
        }

        if (IsAdvantageOnePointBeforeOther(_firstPlayerPoint, _secondPlayerPoint))
        {
            return "Advantage player1";
        }

        if (IsAdvantageOnePointBeforeOther(_secondPlayerPoint, _firstPlayerPoint))
        {
            return "Advantage player2";
        }
        return "";
    }

    private static bool IsOnePointLessThanFourAndGreaterThanOtherPoint(int onePoint, int otherPoint)
    {
        return onePoint > otherPoint && onePoint < 4;
    }

    private static bool IsOnePointGreaterThanZeroAndOtherPointEqualsZero(int onePoint, int otherPoint)
    {
        return onePoint > 0 && otherPoint == 0;
    }

    private static string GetScorePart(int playerPoint)
    {
        return playerPoint switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            3 => "Forty",
            _ => string.Empty
        };
    }

    private string GetScoreForSamePointsLessThanThree()
    {
        return GetScorePart(_firstPlayerPoint) + "-All";
    }

    private static bool IsWinOnePoint(int onePoint, int otherPoint)
    {
        return onePoint >= 4 && otherPoint >= 0 && onePoint - otherPoint >= 2;
    }

    private static bool IsAdvantageOnePointBeforeOther(int onePoint, int otherPoint)
    {
        return onePoint > otherPoint && otherPoint >= 3;
    }

    private bool IsSamePointsGreaterThanTwo()
    {
        return _firstPlayerPoint == _secondPlayerPoint && _firstPlayerPoint > 2;
    }

    private bool IsSamePointsLessThanThree()
    {
        return _firstPlayerPoint == _secondPlayerPoint && _firstPlayerPoint < 3;
    }

    private void P1Score()
    {
        _firstPlayerPoint++;
    }

    private void P2Score()
    {
        _secondPlayerPoint++;
    }

    public void WonPoint(string playerName)
    {
        if (playerName == "player1")
        {
            P1Score();
        }
        else
        {
            P2Score();
        }
    }

}