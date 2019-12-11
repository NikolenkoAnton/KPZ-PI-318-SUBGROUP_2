using App.Deposits.Models;
using System.Collections.Generic;

namespace App.Repositories
{
    public interface IDepositsRepository
    {
        IEnumerable<Deposit> GetAllDeposit();

        Deposit GetDepositById(int id);

        void AddDeposit(Deposit deposit);
    }
}
