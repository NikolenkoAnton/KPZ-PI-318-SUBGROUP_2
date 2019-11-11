using App.Accounts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Accounts.Inerfaces
{
    public interface IAcountsRepository
    {
        IEnumerable<Account> GetActiveBillsList();
        IEnumerable<Account> GetAllBillsList();
        Account GetBillById(int id);
        Account BlockBill(int id);
        Account UnblockBill(int id);

    }
}
