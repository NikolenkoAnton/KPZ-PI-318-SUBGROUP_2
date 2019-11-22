using App.Configuration;
using App.Deposits.Models;
using App.Deposits.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using App.Deposits.Services;
using App.Deposits.Exceptions;
using Microsoft.Extensions.Logging;
using App.Repositories;

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
        private readonly ILogger<DepositsManager> logger;

        public DepositsManager(IDepositsRepository depositsRepository, IValidateService validateService, ILogger<DepositsManager> logger)
        {
            this.depositsRepository = depositsRepository;
            this.validateService = validateService;
            this.logger = logger;
        }

        public void AddDeposit(CreatedDepositDTO newDeposit)
        {
            logger.LogInformation($"Call AddDeposit");

            validateService.ValidateAddDeposit(newDeposit);

            var deposit = new Deposit
            {
                Id = GetIDForNewDeposit(),
                Name = newDeposit.Name,
                InterestRate = newDeposit.InterestRate,
            };

            depositsRepository.AddDeposit(deposit);
        }

        private int GetLastDepositID()
        {
            logger.LogInformation($"Call GetLastDepositID");

            return depositsRepository.GetAllDeposit().OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
        }

        private int GetIDForNewDeposit()
        {
            logger.LogInformation($"Call GetIDForNewDeposit");

            return GetLastDepositID() + 1;
        }

        public Deposit GetDepositById(int id)
        {
            logger.LogInformation($"Call GetDepositById");

            var deposit = depositsRepository.GetDepositById(id);

            if (deposit == null)
            {
                throw new EntityNotExistException(typeof (Deposit), id);
            }

            return deposit;
        }

        public IEnumerable<Deposit> GetAllDeposits()
        {
            logger.LogInformation($"Call GetAllDeposit");

            return depositsRepository.GetAllDeposit();
        }

        public decimal AccrualСalculation(int depositId, CalculateDTO calculateDTO)
        {
            logger.LogInformation($"Call AccrualСalculation");

            var deposit = depositsRepository.GetDepositById(depositId);

            validateService.ValidateCalculateDate(calculateDTO);

            decimal sum = calculateDTO.StartSum + calculateDTO.StartSum * deposit.InterestRate * calculateDTO.GetDaysAmount() / 365;

            return sum;
        }
    }
}
