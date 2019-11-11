using System;

namespace App.Users.Exceptions
{
    class EntityNotFoundException : Exception
    {
        public int Id { get; }

        public EntityNotFoundException(string message, int id) : base(message)
        {
            Id = id;
        }
    }
}
