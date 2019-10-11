using App.Deposits.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Deposits.Controller
{
    [Route("api/deposits")]
    [ApiController]
    public class DepositsController : ControllerBase
    {
        private readonly IDepositsManager depositsManager;
        public DepositsController(IDepositsManager depositsManager)
        {
            this.depositsManager = depositsManager;
        }

        [HttpPost]
        public ActionResult AddDeposit([FromBody]CreatedDepositDTO newDepositr)
        {
            depositsManager.AddDeposit(newDepositr);
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAllDeposits() => Ok(depositsManager.GetAllDeposits());

        [HttpPost]
        public ActionResult AccrualCalculation(int depositId, decimal startSum, DateTime finishDate) => Ok(depositsManager.AccrualСalculation(depositId, startSum, finishDate));

        [HttpGet("/{id}")]
        public ActionResult<Deposit> GetDepositById(int id) => Ok(depositsManager.GetDepositById(id));
      
        

    }
}
