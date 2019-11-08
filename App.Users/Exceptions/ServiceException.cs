using System;
using System.Collections.Generic;
using System.Text;

namespace App.Users.Exceptions
{
    public class ServiceException : Exception
    {
        public int Id { get; }

        public ServiceException(string message, int id)
        : base(message)
        {
            Id = id;
        }
    }
}
