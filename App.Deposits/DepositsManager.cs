using App.Configuration;
using App.Deposits.Models;
using App.Deposits.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Deposits
{
    public interface IDepositsManager
    {
        Deposit GetDepositById(int id);

        void AddDeposit(Deposit deposit);
    }

    public class DepositsManager : IDepositsManager, ITransientDependency
    {
        private readonly IDepositsRepository depositsRepository;

        public DepositsManager(IDepositsRepository depositsRepository)
        {
            this.depositsRepository = depositsRepository;
        }

        public void AddDeposit(Deposit deposit)
        {
            depositsRepository.AddDeposit(deposit);
        }

        public Deposit GetDepositById(int id)
        {
            return depositsRepository.GetDepositById(id);
        }
    }
}
