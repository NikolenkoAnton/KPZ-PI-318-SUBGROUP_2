using App.Configuration;
using App.Deposits.Models;
using App.Deposits.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using App.Deposits.Services;

namespace App.Deposits
{
    public interface IDepositsManager
    {
        Deposit GetDepositById(int id);

        void AddDeposit(CreatedDepositDTO deposit);

        IEnumerable<Deposit> GetAllDeposits();

        decimal AccrualСalculation(int depositId, CalculateDTO calculateDTO);
    }

    public class DepositsManager : IDepositsManager, ITransientDependency
    {
        private readonly IDepositsRepository depositsRepository;
        private readonly IValidateService validateService;

        public DepositsManager(IDepositsRepository depositsRepository, IValidateService validateService)
        {
            this.depositsRepository = depositsRepository;
            this.validateService = validateService;
        }

        public void AddDeposit(CreatedDepositDTO newDeposit)
        {
            validateService.ValidateAddDeposit(newDeposit);

            var deposit = new Deposit
            {
                Id = GetIDForNewDeposit(),
                Name = newDeposit.Name,
                InterestRate = newDeposit.InterestRate,
            };

            depositsRepository.AddDeposit(deposit);
        }

        private int GetLastDepositID() => depositsRepository.GetAllDeposit().OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();

        private int GetIDForNewDeposit() => GetLastDepositID() + 1;

        public Deposit GetDepositById(int id) => depositsRepository.GetDepositById(id);

        public IEnumerable<Deposit> GetAllDeposits() => depositsRepository.GetAllDeposit();

        public decimal AccrualСalculation(int depositId, CalculateDTO calculateDTO)
        {
            var deposit = depositsRepository.GetDepositById(depositId);

            validateService.ValidateCalculateDate(calculateDTO);

            decimal sum = calculateDTO.StartSum + calculateDTO.StartSum * deposit.InterestRate * calculateDTO.GetDaysAmount() / 365;

            return sum;
        }
    }
}
