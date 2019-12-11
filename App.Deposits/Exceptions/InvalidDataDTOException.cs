using System;

namespace App.Deposits.Exceptions
{
    public class InvalidDataDTOException : Exception
    {
        public InvalidDataDTOException(string message) : base(message)
        {

        }
    }
}
