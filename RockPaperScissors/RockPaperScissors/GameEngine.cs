using RockPaperScissors.Errors;

namespace RockPaperScissors
{
    public class GameEngine
    {
        private const string MOVE_ROCK = "R";
        private const string MOVE_SCESSOR = "S";
        private const string MOVE_PAPER = "P";

        public string[] rps_game_winner(string[][] playersMove)
        {
            if (playersMove.Length != 2)
                throw new WrongNumberOfPlayersError($"Expected 2 players. Found {playersMove.Length}");

            var player1 = playersMove[0];
            var player2 = playersMove[1];

            if (!IsValidMove(player1[1]))
                throw new NoSuchStrategyError($"Player {player1[0]} did a invalid move");

            if (!IsValidMove(player2[1]))
                throw new NoSuchStrategyError($"Player {player2[0]} did a invalid move");

            var movePlayer1 = player1[1];
            var movePlayer2 = player2[1];

            if (movePlayer1 == movePlayer2)
                return player1;

            if (movePlayer1 == MOVE_ROCK)
            {
                if (movePlayer2 == MOVE_SCESSOR)
                    return player1;
                return player2;
            }
            else if (movePlayer1 == MOVE_SCESSOR)
            {
                if (movePlayer2 == MOVE_PAPER)
                    return player1;
                return player2;
            }
            else //P
            {
                if (movePlayer2 == MOVE_ROCK)
                    return player1;
                return player2;
            }
        }

        private bool IsValidMove(string move)
        {
            if (move.Equals(MOVE_ROCK) || move.Equals(MOVE_PAPER) || move.Equals(MOVE_SCESSOR))
                return true;
            return false;
        }
    }
}
