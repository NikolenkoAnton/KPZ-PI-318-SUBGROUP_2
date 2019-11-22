using App.Configuration;
using App.Deposits.Exceptions;
using App.Deposits.Models;

namespace App.Deposits.Services
{
    public interface IValidateService
    {
        void ValidateCalculateDate(CalculateDTO calculateDTO);

        void ValidateAddDeposit(CreatedDepositDTO createdDepositDTO);
    }

    public class ValidateService : IValidateService, ITransientDependency
    {
        private bool IsValidDate(CalculateDTO calculateDTO) => calculateDTO.GetDaysAmount() >= 0;

        private bool IsValidInterestRate(CreatedDepositDTO createdDepositDTO) => createdDepositDTO.InterestRate >= 0.01m;

        public void ValidateAddDeposit(CreatedDepositDTO createdDepositDTO)
        {
            if (!IsValidInterestRate(createdDepositDTO))
            {
                throw new InvalidDataDTOException("Invalid interest rate");
            }
        }

        public void ValidateCalculateDate(CalculateDTO calculateDTO)
        {
            if (!IsValidDate(calculateDTO))
            {
                throw new InvalidDataDTOException("Invalid date");
            }
        }
    }
}
