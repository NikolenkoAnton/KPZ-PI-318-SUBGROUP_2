using System;
using System.Collections.Generic;
using System.Text;

namespace App.Users.Exceptions
{
    class RepositoryException : Exception
    {
        public int Id { get; }

        public RepositoryException(string message, int id)
        : base(message)
        {
            Id = id;
        }
    }
}
