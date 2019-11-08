using System;
using System.Collections.Generic;
using System.Text;

namespace App.UserSupport.Exceptions
{
    public class InvalidArgumentException : ArgumentException
    {
        
        public InvalidArgumentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}
