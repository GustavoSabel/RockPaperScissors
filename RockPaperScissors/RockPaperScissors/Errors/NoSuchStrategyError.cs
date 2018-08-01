using System;

namespace RockPaperScissors.Errors
{
    public class NoSuchStrategyError : Exception
    {
        public NoSuchStrategyError(string message) : base(message)
        {
        }
    }
}
