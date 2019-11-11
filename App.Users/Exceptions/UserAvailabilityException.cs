using System;

namespace App.Users.Exceptions
{
    public class UserAvailabilityException : Exception
    {
        public int Id { get; }

        public bool Availability { get; }

        public UserAvailabilityException(string message, int id, bool availability) : base(message)
        {
            Id = id;
            Availability = availability;
        }
    }
}
