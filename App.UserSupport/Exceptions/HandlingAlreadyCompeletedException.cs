using System;
using System.Collections.Generic;
using System.Text;

namespace App.UserSupport.Exceptions
{
    public class HandlingAlreadyCompeletedException : Exception
    {
        public int HandlingId { get; private set; }
        public HandlingAlreadyCompeletedException(int HandlingId)
        {
            this.HandlingId = HandlingId;
        }
    }
}
