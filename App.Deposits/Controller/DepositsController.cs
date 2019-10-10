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
        public ActionResult CreateDeposit(CreatedDepositDTO newDepositr)
        {
            return Ok();
        }

        [HttpGet("/{id}")]
        public ActionResult<Deposit> GetDepositById(int id) => Ok(depositsManager.GetDepositById(id));
      
        

    }
}
