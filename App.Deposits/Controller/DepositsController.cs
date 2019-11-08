using App.Deposits.Filters;
using App.Deposits.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Deposits.Controller
{
    [Route("api/deposits")]
    [ApiController]
    [TypeFilter(typeof(DepositExceptionFilter), Arguments = new object[] { nameof(DepositExceptionFilter) })]
    public class DepositsController : ControllerBase
    {
        private readonly IDepositsManager depositsManager;
        private readonly ILogger<DepositsController> logger;
        public DepositsController(IDepositsManager depositsManager, ILogger<DepositsController> logger)
        {
            this.depositsManager = depositsManager;
            this.logger = logger;
        }

        [HttpPost]
        public ActionResult AddDeposit([FromBody]CreatedDepositDTO newDepositr)
        {
            logger.LogInformation($"Call AddDeposit with Name: {newDepositr.Name}, Interes rate: {newDepositr.InterestRate}");

            depositsManager.AddDeposit(newDepositr);
            return Ok();
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Deposit>> GetAllDeposits()
        {
            logger.LogInformation($"Call GetAllDeposit");

            return Ok(depositsManager.GetAllDeposits());
        }

        [HttpGet("/{id}")]
        public ActionResult<Deposit> GetDepositById(int id)
        {
            logger.LogInformation($"Call GetDepositById(int id) with id: {id}");

            return Ok(depositsManager.GetDepositById(id));
        }

        [HttpGet("/{id}/calculate")]
        public ActionResult AccrualCalculation([FromRoute]int id, [FromQuery]CalculateDTO calculateDTO)
        {
            logger.LogInformation($"Call AccrualCalculation with id: {id}, StartSum: {calculateDTO.StartSum}, FinishDate: {calculateDTO.FinishDate}")

            return Ok(depositsManager.AccrualСalculation(id, calculateDTO));
        }
    }
}
