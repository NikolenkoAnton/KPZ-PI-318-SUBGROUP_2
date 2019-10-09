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
            if (loan == null)
                throw new Exception("Loan doesn't exist");
        }
    }

    public interface IValidateServices
    {
        void ValidateLoan(Loan loan);

    }
}
