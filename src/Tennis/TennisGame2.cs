// ReSharper disable ArrangeThisQualifier
// ReSharper disable EnforceIfStatementBraces

namespace Tennis
{
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

            if (IsFirstPointGreaterThanOrEqualToFourAndSecondPointGreaterThanOrEqualToZeroAndTheirDifferenceGreaterThanTwo())
            {
                return "Win for player1";
            }

            if (IsSecondPointGreaterThanOrEqualToFourAndFirstPointGreaterThanOrEqualToZeroAndTheirDifferenceGreaterThanTwo())
            {
                return "Win for player2";
            }

            if ((_firstPlayerPoint > _secondPlayerPoint && _firstPlayerPoint < 4) ||
                (_secondPlayerPoint > _firstPlayerPoint && _secondPlayerPoint < 4) ||
                IsOnePointGreaterThanZeroAndOtherPointEqualsZero(_firstPlayerPoint, _secondPlayerPoint) ||
                IsOnePointGreaterThanZeroAndOtherPointEqualsZero(_secondPlayerPoint, _firstPlayerPoint))
            {
                return GetScorePart(_firstPlayerPoint) + "-" + GetScorePart(_secondPlayerPoint);
            }

            if (IsSecondPointGreaterThanOrEqualToThreeAndLessThanFirstPoint())
            {
               return "Advantage player1";
            }

            if (IsFirstPointGreaterThanOrEqualToThreeAndLessThanSecondPoint())
            {
               return "Advantage player2";
            }
            return "";
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

        private bool IsSecondPointGreaterThanOrEqualToFourAndFirstPointGreaterThanOrEqualToZeroAndTheirDifferenceGreaterThanTwo()
        {
            return _secondPlayerPoint >= 4 && _firstPlayerPoint >= 0 && (_secondPlayerPoint - _firstPlayerPoint) >= 2;
        }

        private bool IsFirstPointGreaterThanOrEqualToFourAndSecondPointGreaterThanOrEqualToZeroAndTheirDifferenceGreaterThanTwo()
        {
            return _firstPlayerPoint >= 4 && _secondPlayerPoint >= 0 && (_firstPlayerPoint - _secondPlayerPoint) >= 2;
        }

        private bool IsFirstPointGreaterThanOrEqualToThreeAndLessThanSecondPoint()
        {
            return _secondPlayerPoint > _firstPlayerPoint && _firstPlayerPoint >= 3;
        }

        private bool IsSecondPointGreaterThanOrEqualToThreeAndLessThanFirstPoint()
        {
            return _firstPlayerPoint > _secondPlayerPoint && _secondPlayerPoint >= 3;
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
}

