using System;
using System.Collections.Generic;
using System.Text;

namespace App.Users.Exceptions
{
    public class PasswordVerificationException : Exception
    {
        public int Id { get; }

        public PasswordVerificationException(string message, int id) : base(message)
        {
            Id = id;
        }
    }
}
