using System;
using System.Collections.Generic;
using System.Text;

namespace App.Deposits.Exceptions
{
    public class InvalidDataDTOException : Exception
    {
        public InvalidDataDTOException(string message) : base(message)
        {

        }
    }
}
