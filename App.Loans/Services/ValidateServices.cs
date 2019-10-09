using System;
using System.Collections.Generic;
using System.Text;
using App.Loans.Models;

namespace App.Loans
{
    public class ValidateServices : IValidateServices
    {
        public void ValidateLoan(Loan loan)
        {
            if (loan.moneyLeft == 0)
                throw new Exception("Loan is already paid!");
        }
    }

    public interface IValidateServices
    {
        void ValidateLoan(Loan loan);
    }
}
