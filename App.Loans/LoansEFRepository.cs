using System.Linq;
using System.Collections.Generic;
using System.Text;
using App.Loans.Repositories;
using App.Configuration;
using App.Loans.Models;

namespace App.Loans
{
    public class LoansEFRepository : ILoansRepository,ISingletoneDependency
    {
        private readonly LoansDBContext _loanDbContext;
        public LoansEFRepository(LoansDBContext loansDBContext)
        {
            _loanDbContext = loansDBContext;
        }
        public IEnumerable<Loan> GetActiveLoansList() => _loanDbContext.Loans;
        public Loan GetLoanById(int id) => _loanDbContext.Loans.Where(f => f.Id == id).FirstOrDefault();
    }
}
