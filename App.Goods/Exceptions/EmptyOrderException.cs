using System;

namespace App.Goods.Exceptions
{
    public class EmptyOrderException : Exception
    {
        public EmptyOrderException(string message) : base(message) { }
    }
}
