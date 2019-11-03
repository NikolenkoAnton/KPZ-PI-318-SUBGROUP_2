using System.Collections.Generic;
using App.Configuration;
using App.Repositories;
using App.Loans.Models;
using App.Loans.Repositories;

namespace App.Loans.Services
{
    public interface ILoansManager
    {
        Loan GetItem(int id);
        IEnumerable<string> GetListActiveLoans();
        double GetMoneyLeft(int id);
    }

    public class LoansManager : ILoansManager, ITransientDependency
    {
        readonly LoansRepository _repository;

        public Loan GetItem(int id) => _repository.GetLoanById(id);

        public LoansManager(LoansRepository repository)
        {
            _repository = repository;
        }

        public double GetMoneyLeft(int id)
        {
            return _repository.GetLoanById(id).moneyLeft;
        }

        public IEnumerable<string> GetListActiveLoans()
        {
            return _repository.GetActiveLoansList();
        }
    }
}
