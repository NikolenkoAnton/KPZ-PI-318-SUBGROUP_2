using System;

namespace App.Users.Exception
{
    public class EntityNotFoundException : System.Exception
    {
        public int Id { get; }

        public EntityNotFoundException(string message, int id) :
            base(message)
        {
            Id = id;
        }
    }
}
