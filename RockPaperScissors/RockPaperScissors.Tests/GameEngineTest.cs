using System;
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

        [Fact]
        public void TounamentWith2Players()
        {
            var gameEngine = new GameEngine();
            var winner = gameEngine.rps_tournament_winner(
                new[] {
                    new[] { new[] { "Armando", "P" }, new[] { "Dave", "S" } },
                }
            );

            Assert.Equal("Dave", winner[0]);
            Assert.Equal("S", winner[1]);
        }

        [Fact]
        public void TounamentWith4Players()
        {
            var gameEngine = new GameEngine();
            var winner = gameEngine.rps_tournament_winner(
                new[] {
                    new[] { new[] { "Armando", "P" }, new[] { "Dave", "S" } },
                    new[] { new[] { "Richard", "R" }, new[] { "Michael", "S" } },
                }
            );

            Assert.Equal("Richard", winner[0]);
            Assert.Equal("R", winner[1]);
        }

        [Fact]
        public void TounamentWith8Players()
        {
            var gameEngine = new GameEngine();
            var winner = gameEngine.rps_tournament_winner(
                new[] {
                    new[] { new[] { "Armando", "P" }, new[] { "Dave", "S" } },
                    new[] { new[] { "Richard", "R" }, new[] { "Michael", "S" } },
                    new[] { new[] { "Allen", "S" }, new[] { "Omer", "P" } },
                    new[] { new[] { "David E.", "R" }, new[] { "Richard X.", "P" } },
                }
            );

            Assert.Equal("Richard", winner[0]);
            Assert.Equal("R", winner[1]);
        }

        [Fact]
        public void TounamentWith16Players()
        {
            var gameEngine = new GameEngine();
            var winner = gameEngine.rps_tournament_winner(
                new[] {
                    new[] { new[] { "Armando", "P" }, new[] { "Dave", "S" } },
                    new[] { new[] { "Richard", "R" }, new[] { "Michael", "S" } },
                    new[] { new[] { "Allen", "S" }, new[] { "Omer", "P" } },
                    new[] { new[] { "David E.", "R" }, new[] { "Richard X.", "P" } },

                    new[] { new[] { "Owen", "S" }, new[] { "Rhys", "R" } },
                    new[] { new[] { "Jacob", "P" }, new[] { "Elijah", "P" } },
                    new[] { new[] { "Oscar", "S" }, new[] { "Kody", "S" } },
                    new[] { new[] { "Mason", "R" }, new[] { "Ernesto", "S" } },
                }
            );

            Assert.Equal("Jacob", winner[0]);
            Assert.Equal("P", winner[1]);
        }

        [Fact]
        public void TounamentWith1024Players()
        {
            string[] moves = new string[] { "R", "S", "P" };
            var random = new Random(Guid.NewGuid().GetHashCode());

            var gameEngine = new GameEngine();

            var playersAndMoves = new string[512][][];
            for (int i = 0; i < 1024; i += 2)
            {
                playersAndMoves[i / 2] = new[] {
                    new[] { $"Player{i.ToString("0000")}", moves[random.Next(0, 3)] },
                    new[] { $"Player{(i + 1).ToString("0000")}", moves[random.Next(0, 3)] }
                };
            }

            var winner = gameEngine.rps_tournament_winner(playersAndMoves);

            Assert.NotNull(winner);
            Assert.Equal(2, winner.Length);
        }
    }
}
