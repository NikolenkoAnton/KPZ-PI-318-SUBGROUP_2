using System;
using System.Collections.Generic;
using System.Text;

namespace App.Users.Exception
{
    public class PasswordVerificationException : BadRequestException
    {
        public PasswordVerificationException(string message, int id) : 
            base(message, id)
        {
        }
    }
}
