using App.Configuration;
using App.Deposits.Models;
using App.Repositories;
using System;
using System.Collections.Generic;

namespace App.Deposits.Repositories
{
    public class EfDepositsRepository : IDepositsRepository, IDisposable, ITransientDependency
    {
        public void AddDeposit(Deposit deposit)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Deposit> GetAllDeposit()
        {
            throw new NotImplementedException();
        }

        public Deposit GetDepositById(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
