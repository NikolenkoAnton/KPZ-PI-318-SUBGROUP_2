using System;

namespace App.Loans.Exceptions
{
    public class LoanAlreadyPaidException : Exception
    {
        public int LoanId { get; private set; }
        public LoanAlreadyPaidException(int LoanId)
        {
            this.LoanId = LoanId;
        }
    }
}
