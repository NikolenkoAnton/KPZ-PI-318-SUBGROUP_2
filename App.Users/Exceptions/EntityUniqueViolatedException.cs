using System;
using System.Collections.Generic;
using System.Text;

namespace App.Users.Exceptions
{
    class EntityUniqueViolatedException : Exception
    {
        public int Id { get; }

        public EntityUniqueViolatedException(string message, int id) : base(message)
        {
            Id = id;
        }
    }
}
