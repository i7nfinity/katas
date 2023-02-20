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
            if (_firstPlayerPoint == _secondPlayerPoint && _firstPlayerPoint < 3)
            {
                if (_firstPlayerPoint == 0)
                    score = "Love";
                if (_firstPlayerPoint == 1)
                    score = "Fifteen";
                if (_firstPlayerPoint == 2)
                    score = "Thirty";
                score += "-All";
            }
            if (_firstPlayerPoint == _secondPlayerPoint && _firstPlayerPoint > 2)
                score = "Deuce";

            if (_firstPlayerPoint > 0 && _secondPlayerPoint == 0)
            {
                if (_firstPlayerPoint == 1)
                    p1res = "Fifteen";
                if (_firstPlayerPoint == 2)
                    p1res = "Thirty";
                if (_firstPlayerPoint == 3)
                    p1res = "Forty";

                p2res = "Love";
                score = p1res + "-" + p2res;
            }
            if (_secondPlayerPoint > 0 && _firstPlayerPoint == 0)
            {
                if (_secondPlayerPoint == 1)
                    p2res = "Fifteen";
                if (_secondPlayerPoint == 2)
                    p2res = "Thirty";
                if (_secondPlayerPoint == 3)
                    p2res = "Forty";

                p1res = "Love";
                score = p1res + "-" + p2res;
            }

            if (_firstPlayerPoint > _secondPlayerPoint && _firstPlayerPoint < 4)
            {
                if (_firstPlayerPoint == 2)
                    p1res = "Thirty";
                if (_firstPlayerPoint == 3)
                    p1res = "Forty";
                if (_secondPlayerPoint == 1)
                    p2res = "Fifteen";
                if (_secondPlayerPoint == 2)
                    p2res = "Thirty";
                score = p1res + "-" + p2res;
            }
            if (_secondPlayerPoint > _firstPlayerPoint && _secondPlayerPoint < 4)
            {
                if (_secondPlayerPoint == 2)
                    p2res = "Thirty";
                if (_secondPlayerPoint == 3)
                    p2res = "Forty";
                if (_firstPlayerPoint == 1)
                    p1res = "Fifteen";
                if (_firstPlayerPoint == 2)
                    p1res = "Thirty";
                score = p1res + "-" + p2res;
            }

            if (_firstPlayerPoint > _secondPlayerPoint && _secondPlayerPoint >= 3)
            {
                score = "Advantage player1";
            }

            if (_secondPlayerPoint > _firstPlayerPoint && _firstPlayerPoint >= 3)
            {
                score = "Advantage player2";
            }

            if (_firstPlayerPoint >= 4 && _secondPlayerPoint >= 0 && (_firstPlayerPoint - _secondPlayerPoint) >= 2)
            {
                score = "Win for player1";
            }
            if (_secondPlayerPoint >= 4 && _firstPlayerPoint >= 0 && (_secondPlayerPoint - _firstPlayerPoint) >= 2)
            {
                score = "Win for player2";
            }
            return score;
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
                P1Score();
            else
                P2Score();
        }

    }
}

