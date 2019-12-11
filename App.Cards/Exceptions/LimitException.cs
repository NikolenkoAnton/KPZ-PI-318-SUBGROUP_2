using System;

namespace App.Cards.Exceptions
{
    public class LimitException : Exception
    {
        public string LimitAction { get; set; }
        public LimitException(string LimitAction, string message) : base(message)
        {
            this.LimitAction = LimitAction;
        }
    }
}
