// ReSharper disable ArrangeThisQualifier
// ReSharper disable EnforceIfStatementBraces
namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _firstPlayerPoint;
        private int _secondPlayerPoint;

        private string p1res = "";
        private string p2res = "";

        public string GetScore()
        {
            var score = "";
            if (IsSamePointsLessThanThree())
            {
                return GetScoreForSamePointsLessThanThree(score);
            }
            if (IsSamePointsGreaterThanTwo())
            {
                score = "Deuce";
            }

            if (IsFirstPointGreaterThanZeroAndSecondPointEqualsZero())
            {
                if (_firstPlayerPoint == 1)
                {
                    p1res = "Fifteen";
                }

                if (_firstPlayerPoint == 2)
                {
                    p1res = "Thirty";
                }

                if (_firstPlayerPoint == 3)
                {
                    p1res = "Forty";
                }

                p2res = "Love";
                score = p1res + "-" + p2res;
            }
            if (IsSecondPointGreaterThanZeroAndFirstPointEqualsZero())
            {
                if (_secondPlayerPoint == 1)
                {
                    p2res = "Fifteen";
                }

                if (_secondPlayerPoint == 2)
                {
                    p2res = "Thirty";
                }

                if (_secondPlayerPoint == 3)
                {
                    p2res = "Forty";
                }

                p1res = "Love";
                score = p1res + "-" + p2res;
            }

            if (IsFirstPointLessThanFourAndGreaterThanSecondPoint())
            {
                if (_firstPlayerPoint == 2)
                {
                    p1res = "Thirty";
                }

                if (_firstPlayerPoint == 3)
                {
                    p1res = "Forty";
                }

                if (_secondPlayerPoint == 1)
                {
                    p2res = "Fifteen";
                }

                if (_secondPlayerPoint == 2)
                {
                    p2res = "Thirty";
                }

                score = p1res + "-" + p2res;
            }
            if (IsSecondPointLessThanFourAndGreaterThanFirstPoint())
            {
                if (_secondPlayerPoint == 2)
                {
                    p2res = "Thirty";
                }

                if (_secondPlayerPoint == 3)
                {
                    p2res = "Forty";
                }

                if (_firstPlayerPoint == 1)
                {
                    p1res = "Fifteen";
                }

                if (_firstPlayerPoint == 2)
                {
                    p1res = "Thirty";
                }

                score = p1res + "-" + p2res;
            }

            if (IsSecondPointGreaterThanOrEqualToThreeAndLessThanFirstPoint())
            {
                score = "Advantage player1";
            }

            if (IsFirstPointGreaterThanOrEqualToThreeAndLessThanSecondPoint())
            {
                score = "Advantage player2";
            }

            if (IsFirstPointGreaterThanOrEqualToFourAndSecondPointGreaterThanOrEqualToZeroAndTheirDifferenceGreaterThanTwo())
            {
                score = "Win for player1";
            }
            if (IsSecondPointGreaterThanOrEqualToFourAndFirstPointGreaterThanOrEqualToZeroAndTheirDifferenceGreaterThanTwo())
            {
                score = "Win for player2";
            }
            return score;
        }

        private string GetScoreForSamePointsLessThanThree(string score)
        {
            if (_firstPlayerPoint == 0)
            {
                score = "Love";
            }

            if (_firstPlayerPoint == 1)
            {
                score = "Fifteen";
            }

            if (_firstPlayerPoint == 2)
            {
                score = "Thirty";
            }

            return score + "-All";
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

        private bool IsSecondPointLessThanFourAndGreaterThanFirstPoint()
        {
            return _secondPlayerPoint > _firstPlayerPoint && _secondPlayerPoint < 4;
        }

        private bool IsFirstPointLessThanFourAndGreaterThanSecondPoint()
        {
            return _firstPlayerPoint > _secondPlayerPoint && _firstPlayerPoint < 4;
        }

        private bool IsSecondPointGreaterThanZeroAndFirstPointEqualsZero()
        {
            return _secondPlayerPoint > 0 && _firstPlayerPoint == 0;
        }

        private bool IsFirstPointGreaterThanZeroAndSecondPointEqualsZero()
        {
            return _firstPlayerPoint > 0 && _secondPlayerPoint == 0;
        }

        private bool IsSamePointsGreaterThanTwo()
        {
            return _firstPlayerPoint == _secondPlayerPoint && _firstPlayerPoint > 2;
        }

        private bool IsSamePointsLessThanThree()
        {
            return _firstPlayerPoint == _secondPlayerPoint && _firstPlayerPoint < 3;
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            _firstPlayerPoint++;
        }

        private void P2Score()
        {
            _secondPlayerPoint++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
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

