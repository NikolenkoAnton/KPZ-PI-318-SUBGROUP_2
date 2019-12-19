using System;
using System.Collections.Generic;
using System.Text;

namespace App.Users.Exception
{
    public class EntityUniqueViolatedException : BadRequestException
    {
        public EntityUniqueViolatedException(string message, int id) : 
            base(message, id)
        {
        }
    }
}
