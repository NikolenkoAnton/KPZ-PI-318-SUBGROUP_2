using System;
using System.Collections.Generic;
using System.Text;
using App.Accounts.Inerfaces;
using App.Accounts.Models;
using App.Configuration;
using App.Repositories;

namespace App.Accounts.Repositories
{
  
    public class InMemoryAccountsRepository : IAcountsRepository, ITransientDependency
    {
       
        private static Account[] bills = {
            new Account(34000, "Vasya", "Pupkin"),
            new Account(17000, "Petro", "Poroshenko"),
            new Account(7000, "Maria", "Ivanovna"),
            new Account(-15000, "Anna", "Ivanovna")};

        public IEnumerable<Account> GetActiveBillsList()
        {
            List<Account> ActiveBillsList = new List<Account>();
            for (int i = 0; i < bills.Length; i++)
            {
                if (!bills[i].IsBlocked)
                    ActiveBillsList.Add(bills[i]);
            }
            return ActiveBillsList;
        }

        public IEnumerable<Account> GetAllBillsList()
        {
            List<Account> AllBillsList = new List<Account>();
            for (int i = 0; i < bills.Length; i++)
            {
                 AllBillsList.Add(bills[i]);
            }

            return AllBillsList;
        }

        public Account GetBillById(int id)
        {
            if (id >= bills.Length)
                return null;
            return bills[id];
        }

        public Account BlockBill(int id)
        {
            if (id >= bills.Length)
                return null;
            bills[id].IsBlocked = true;
            return bills[id];
        }

        public Account UnblockBill(int id)
        {
            if (id >= bills.Length)
                return null;
            bills[id].IsBlocked = false;
            return bills[id];
        }
    }
}
