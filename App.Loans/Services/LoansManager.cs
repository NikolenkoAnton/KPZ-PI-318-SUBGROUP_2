using System.Collections.Generic;
using App.Configuration;
using App.Repositories;
using App.Loans.Models;
using App.Loans.Repositories;
using Microsoft.Extensions.Logging;
using App.Loans.Exceptions;
namespace App.Loans.Services
{
    public interface ILoansManager
    {
        Loan GetItem(int id);
        IEnumerable<Loan> GetListActiveLoans();
        double GetMoneyLeft(int id);
    }

    public class LoansManager : ILoansManager, ITransientDependency
    {
        readonly ILoansRepository _repository;
        private readonly ILogger<LoansManager> logger;

        public Loan GetItem(int id)
        {
            var get = _repository.GetLoanById(id);
            logger.LogDebug("Method:GetItem");
            if (get == null)
                throw new EntityNotFoundException(typeof(Loan));
            return get;
        }
        public LoansManager(ILoansRepository repository,
            ILogger<LoansManager> _logger)
        {
            _repository = repository;
            logger = _logger;
        }

        public double GetMoneyLeft(int id)
        {
            var get = _repository.GetLoanById(id);
            logger.LogDebug("Method:GetMoneyLeft");
            if (get == null)
                throw new EntityNotFoundException(typeof(Loan));
            logger.LogDebug("Method:GetMoneyLeft");
            if (get.moneyLeft == 0)
                throw new LoanAlreadyPaidException(id);
            return get.moneyLeft;
        }

        public IEnumerable<Loan> GetListActiveLoans()
        {
            return _repository.GetActiveLoansList();
        }
    }
}
