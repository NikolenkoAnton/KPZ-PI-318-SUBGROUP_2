using System;
using System.Collections.Generic;
using System.Text;

namespace App.Customers.Models
{
    public class CreditCard
    {
        public long CardNumber { get; }
        public int CVV2 { get; }
        public DateTime Validity { get; }

        public CreditCard(long cardNumber, int cvv2, DateTime validity)
        {
            this.CardNumber = cardNumber;
            this.CVV2 = cvv2;
            this.Validity = validity;
        }

        public override string ToString()
        {
            return $"Card number:{CardNumber}, CVV2:{CVV2}, Validity:{Validity}";
        }
    }
}
