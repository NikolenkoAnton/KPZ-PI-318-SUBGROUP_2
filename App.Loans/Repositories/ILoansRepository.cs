using System;
using System.Collections.Generic;
using System.Text;
using App.Loans.Models;
using App.Configuration;
using App.Repositories;
using System.Linq;

namespace App.Loans.Repositories
{
    public interface ILoansRepository
    {
        IQueryable<Loan> GetActiveLoansList();

        Loan GetLoanById(int id);
    }
}
