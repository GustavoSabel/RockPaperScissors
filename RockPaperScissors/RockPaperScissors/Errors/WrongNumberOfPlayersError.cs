using System;

namespace RockPaperScissors.Errors
{
    public class WrongNumberOfPlayersError : Exception
    {
        public WrongNumberOfPlayersError(string message) : base(message)
        {
        }
    }
}
