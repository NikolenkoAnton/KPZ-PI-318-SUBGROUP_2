using App.Accounts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Accounts.Inerfaces
{
    public interface IAccountManager
    {
        Account GetBillById(int id);
        IEnumerable<Account> GetUnblockedBillsList();
        IEnumerable<Account> GetAllBillsList();
        Account BlockBill(int id);
        Account UnblockBill(int id);
    }
}
