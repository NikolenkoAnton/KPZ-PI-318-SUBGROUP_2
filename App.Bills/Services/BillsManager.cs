﻿using System.Collections.Generic;
using App.Configuration;
using App.Repositories;
using App.Bills.Models;
using App.Bills.Repositories;

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

        public Bill GetBillById(int id) =>   _repository.GetBillById(id);
            
        public BillsManager(InMemoryBillRepository repository,  IValidateServices validateServices)
        {
            this.validateServices = validateServices;
            _repository = repository;
        }
        
        public IEnumerable<Bill> GetUnblockedBillsList()
        {
            return _repository.GetActiveBillsList();
        }

        public IEnumerable<Bill> GetAllBillsList()
        {
            return _repository.GetAllBillsList();
        }

        public Bill BlockBill(int id)
        {
            validateServices.ValidateBill(_repository.GetBillById(id));
            return _repository.BlockBill(id);
        }

        public Bill UnblockBill(int id)
        {
            validateServices.ValidateBill(_repository.GetBillById(id));
            return _repository.UnblockBill(id);
        }
    }
}
