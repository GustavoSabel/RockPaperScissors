using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameEngine = new GameEngine();
            var winner = gameEngine.rps_game_winner(new[] { new[] { "Gustavo", "P" }, new[] { "Maria", "R" } });
            Console.WriteLine("Winner: " + winner[0]);

            Console.ReadKey();
        }
    }
}
