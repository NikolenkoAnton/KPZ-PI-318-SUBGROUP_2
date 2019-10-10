using App.Configuration;
using App.Deposits.Models;
using App.Deposits.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace App.Deposits
{
    public interface IDepositsManager
    {
        Deposit GetDepositById(int id);

        void AddDeposit(CreatedDepositDTO deposit);
        IEnumerable<Deposit> GetAllDeposits();
    }

    public class DepositsManager : IDepositsManager, ITransientDependency
    {
        private readonly IDepositsRepository depositsRepository;

        public DepositsManager(IDepositsRepository depositsRepository)
        {
            this.depositsRepository = depositsRepository;
        }

        public void AddDeposit(CreatedDepositDTO newDeposit)
        {
            var deposit = new Deposit { 
                Id = GetLastDepositID(), 
                Name = newDeposit.Name, 
                InterastRate = newDeposit.InterastRate };

            depositsRepository.AddDeposit(deposit);
        }

        public Deposit GetDepositById(int id)
        {
            return depositsRepository.GetDepositById(id);
        }

        public IEnumerable<Deposit> GetAllDeposits()
        {
            return depositsRepository.GetAllDeposit();
        }

        private int GetLastDepositID() => depositsRepository.GetAllDeposit().OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();

        private int GetIDForNewDeposit() => GetLastDepositID() + 1;
    }
}
