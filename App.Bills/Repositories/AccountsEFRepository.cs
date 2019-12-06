using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Accounts.Inerfaces;
using App.Accounts.Models;
using App.Configuration;
using App.Repositories;

namespace App.Accounts.Repositories
{
  
    public class AccountsEFRepository : IAcountsRepository, ITransientDependency
    {
        private readonly AccountsDbContext _acountDbContext;
        public AccountsEFRepository(AccountsDbContext stockDbContext)
        {
            _acountDbContext = stockDbContext;
        }

        public IEnumerable<Account> GetActiveBillsList() => _acountDbContext.Accounts.Where(a => a.IsBlocked == false).ToList();
        public IEnumerable<Account> GetAllBillsList() => _acountDbContext.Accounts.ToList();
        public Account GetBillById(int id) => _acountDbContext.Accounts.Where(a => a.Id == id).FirstOrDefault();
        public Account BlockBill(int id)
        {
            Account account = GetBillById(id);
            account.IsBlocked = true;
            _acountDbContext.Accounts.Update(account);
            _acountDbContext.SaveChanges();
            return GetBillById(id);
        }
        public Account UnblockBill(int id)
        {
            Account account = GetBillById(id);
            account.IsBlocked = false;
            _acountDbContext.Accounts.Update(account);
            _acountDbContext.SaveChanges();
            return GetBillById(id);
        }
    }
}
