using App.Configuration;
using App.Deposits.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace App.Deposits.Repositories
{
    public interface IDepositsRepository
    {
        IEnumerable<Deposit> GetAllDeposit();

        Deposit GetDepositById(int id);

        void AddDeposit(Deposit deposit);
    }

    public class InMemmoryDepositsRepository : IDepositsRepository, ITransientDependency
    {
        private static readonly List<Deposit> deposits = Init();

        private static List<Deposit> Init()
        {
            var deposits = new List<Deposit>();

            deposits.Add(new Deposit { Id = 1, Name = "Defoult", InterestRate = 0.15m });
            deposits.Add(new Deposit { Id = 2, Name = "Students", InterestRate = 0.20m });
            deposits.Add(new Deposit { Id = 3, Name = "Retirement", InterestRate = 0.25m });

            return deposits;
        }
        public void AddDeposit(Deposit deposit) => deposits.Add(deposit);

        public IEnumerable<Deposit> GetAllDeposit() => deposits;

        public Deposit GetDepositById(int id)
        {
            var deposit = deposits.Where(x => x.Id == id).FirstOrDefault();

            return deposit;
        }
        

    }
}
