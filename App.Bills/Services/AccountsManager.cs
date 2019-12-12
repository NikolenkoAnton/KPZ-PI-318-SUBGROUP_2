using System.Collections.Generic;
using App.Configuration;
using App.Repositories;
using App.Accounts.Models;
using App.Accounts.Repositories;
using Microsoft.Extensions.Logging;
using System.Linq;
using App.Accounts.Exceptions;
using App.Accounts.Inerfaces;

namespace App.Accounts.Services
{
   

    public class AccountsManager : IAccountManager, ITransientDependency
    {
        readonly IAcountsRepository _repository;
        private IValidateServices validateServices;
        private readonly ILogger<AccountsManager> logger;

        

        public AccountsManager(IAcountsRepository repository,  IValidateServices validateServices, ILogger<AccountsManager> logger)
        {
            this.validateServices = validateServices;
            this.logger = logger;
            _repository = repository;
        }

        public Account GetBillById(int id)
        {
            logger.LogDebug($"Method:GetBillById");
            if (_repository.GetBillById(id) == null)
                throw new EntityNotFoundException(typeof(Account));
            return _repository.GetBillById(id);
        }

        public IEnumerable<Account> GetUnblockedBillsList()
        {
            logger.LogDebug($"Method:BlockCard");
            return _repository.GetActiveBillsList();
        }

        public IEnumerable<Account> GetAllBillsList()
        {
            return _repository.GetAllBillsList();
        }

        public Account BlockBill(int id)
        {
            logger.LogDebug($"Method:BlockBill");
            if (_repository.GetBillById(id) == null)
                throw new EntityNotFoundException(typeof(Account));
            if (_repository.GetBillById(id).IsBlocked == true)
                throw new BillAlreadyBlockedException(id);
            validateServices.ValidateBill(_repository.GetBillById(id));
            return _repository.BlockBill(id);
        }

        public Account UnblockBill(int id)
        {
            logger.LogDebug($"Method:UnblockBill");
            if (_repository.GetBillById(id) == null)
                throw new EntityNotFoundException(typeof(Account));
            if (_repository.GetBillById(id).IsBlocked == false)
                throw new BillAlreadyUnlockedException(id);
            validateServices.ValidateBill(_repository.GetBillById(id));
            return _repository.UnblockBill(id);
        }
    }
}
