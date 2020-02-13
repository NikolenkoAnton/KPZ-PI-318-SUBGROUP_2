using System;
using System.Collections.Generic;
using System.Text;

namespace App.Customers.Exceptions
{
    public class EntityUniqueCardExceptions:Exception
    {
        public long CardNumber { get; private set; }
        public EntityUniqueCardExceptions(long cardNumber)
        {
            this.CardNumber = cardNumber;
        }
        
    }
}
