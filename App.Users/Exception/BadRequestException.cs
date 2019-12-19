using System;
using System.Collections.Generic;
using System.Text;

namespace App.Users.Exception
{
    public class BadRequestException : System.Exception
    {
        public int Id { get; }

        public BadRequestException(string message, int id) : 
            base(message)
        {
            Id = id;
        }
    }
}
