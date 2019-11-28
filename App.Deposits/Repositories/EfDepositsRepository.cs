using App.Configuration;
using App.Deposits.DataBase;
using App.Deposits.Models;
using App.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Deposits.Repositories
{
    public class EfDepositsRepository : IDepositsRepository, IDisposable, ITransientDependency
    {
        private readonly DepositsDbContext dbContext;

        public EfDepositsRepository(DepositsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddDeposit(Deposit deposit)
        {
            dbContext.Deposits.Add(deposit);

            dbContext.SaveChanges();
        }

        public IEnumerable<Deposit> GetAllDeposit() => dbContext.Deposits;

        public Deposit GetDepositById(int id)
        {
            var deposit = dbContext.Deposits.Where(x => x.Id == id).FirstOrDefault();

            return deposit;
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }
    }
}
