using System.Collections.Generic;
using App.Configuration;
using App.Repositories;
using App.Bills.Models;
using App.Bills.Repositories;
using Microsoft.Extensions.Logging;
using System.Linq;
using App.Bills.Exceptions;

namespace App.Bills.Services
{
    public interface IBillsManager
    {
        Bill GetBillById(int id);
        IEnumerable<Bill> GetUnblockedBillsList();
        IEnumerable<Bill> GetAllBillsList();
        Bill BlockBill(int id);
    }

    public class BillsManager : IBillsManager, ITransientDependency
    {
        readonly InMemoryBillRepository _repository;
        private IValidateServices validateServices;
        private readonly ILogger<BillsManager> logger;

        public Bill GetBillById(int id)
        {
            logger.LogDebug($"Method:GetBillById");
            if (_repository.GetBillById(id) == null)
                throw new EntityNotFoundException(typeof(Bill));
            return _repository.GetBillById(id);
        }

        public BillsManager(InMemoryBillRepository repository,  IValidateServices validateServices, ILogger<BillsManager> logger)
        {
            this.validateServices = validateServices;
            this.logger = logger;
            _repository = repository;
        }
        
        public IEnumerable<Bill> GetUnblockedBillsList()
        {
            logger.LogDebug($"Method:BlockCard");
            return _repository.GetActiveBillsList();
        }

        public IEnumerable<Bill> GetAllBillsList()
        {
            return _repository.GetAllBillsList();
        }

        public Bill BlockBill(int id)
        {
            logger.LogDebug($"Method:BlockBill");
            if (_repository.GetBillById(id) == null)
                throw new EntityNotFoundException(typeof(Bill));
            if (_repository.GetBillById(id).IsBlocked == true)
                throw new BillAlreadyBlockedException(id);
            validateServices.ValidateBill(_repository.GetBillById(id));
            return _repository.BlockBill(id);
        }

        public Bill UnblockBill(int id)
        {
            logger.LogDebug($"Method:UnblockBill");
            if (_repository.GetBillById(id) == null)
                throw new EntityNotFoundException(typeof(Bill));
            if (_repository.GetBillById(id).IsBlocked == false)
                throw new BillAlreadyUnlockedException(id);
            validateServices.ValidateBill(_repository.GetBillById(id));
            return _repository.UnblockBill(id);
        }
    }
}
