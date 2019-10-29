using System.Collections.Generic;
using App.Configuration;
using App.Repositories;
using App.Bills.Models;
using App.Bills.Repositories;

namespace App.Bills.Services
{
    public interface IBillsManager
    {
        string GetBillById(int id);
        IEnumerable<string> GetUnblockedBillsList();
        IEnumerable<string> GetAllBillsList();
        string BlockBill(int id);
    }

    public class BillsManager : IBillsManager, ITransientDependency
    {
        readonly BillRepository _repository;

        public string GetBillById(int id) =>   _repository.GetBillById(id);
            

        public BillsManager(BillRepository repository)
        {
            _repository = repository;
        }

        
        public IEnumerable<string> GetUnblockedBillsList()
        {
            return _repository.GetActiveBillsList();
        }

        public IEnumerable<string> GetAllBillsList()
        {
            return _repository.GetAllBillsList();
        }

        public string BlockBill(int id)
        {
            return _repository.BlockBill(id);
            
        }

        public string UnblockBill(int id)
        {
            return _repository.UnblockBill(id);

        }
    }
}
