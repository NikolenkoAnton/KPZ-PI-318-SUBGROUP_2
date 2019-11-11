using System;

namespace App.Loans.Exceptions
{
    public class LoanAlreadyPaidException : Exception
    {
        public int HandlingId { get; private set; }
        public LoanAlreadyPaidException(int HandlingId)
        {
            this.HandlingId = HandlingId;
        }
    }
}
