using System;
using System.Collections.Generic;
using System.Text;

namespace App.Users.Exceptions
{
    class PasswordVerificationException : Exception
    {
        public int Id { get; }

        public PasswordVerificationException(string message, int id) : base(message)
        {
            Id = id;
        }
    }
}
