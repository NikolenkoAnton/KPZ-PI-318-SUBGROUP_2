using System;

namespace App.Users.Exception
{
    public class UserAvailabilityException : BadRequestException
    {
        public bool Availability { get; }

        public UserAvailabilityException(string message, int id, bool availability) : 
            base(message, id)
        {
            Availability = availability;
        }
    }
}
