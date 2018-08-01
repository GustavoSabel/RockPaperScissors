using Xunit;

namespace RockPaperScissors.Tests
{
    public class GameEngineTest
    {
        [Theory]
        [InlineData("PlayerA", "P", "PlayerB", "R", "PlayerA", "P")]
        [InlineData("PlayerA", "R", "PlayerB", "P", "PlayerB", "P")]
        [InlineData("PlayerA", "P", "PlayerB", "S", "PlayerB", "S")]
        [InlineData("PlayerA", "S", "PlayerB", "P", "PlayerA", "S")]
        [InlineData("PlayerA", "R", "PlayerB", "S", "PlayerA", "R")]
        [InlineData("PlayerA", "S", "PlayerB", "R", "PlayerB", "R")]
        [InlineData("PlayerA", "P", "PlayerB", "P", "PlayerA", "P")]
        [InlineData("PlayerA", "R", "PlayerB", "R", "PlayerA", "R")]
        [InlineData("PlayerA", "S", "PlayerB", "S", "PlayerA", "S")]
        public void Win(string player1, string move1, string player2, string move2, string playerWinner, string moveWinner)
        {
            var gameEngine = new GameEngine();
            var winner = gameEngine.rps_game_winner(new[] { new[] { player1, move1 }, new[] { player2, move2 } });
            Assert.Equal(playerWinner, winner[0]);
            Assert.Equal(moveWinner, winner[1]);
        }
    }
}
