using System;
using System.Collections.Generic;
using System.Text;

namespace App.UserSupport.Exceptions
{
    class ClientAlredyExistException : Exception
    {
        public ClientAlredyExistException(string message) : base(message)
        {
        }
    }
}
