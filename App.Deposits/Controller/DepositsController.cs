﻿using App.Deposits.Models;
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

        [HttpGet("all")]
        public ActionResult<IEnumerable<Deposit>> GetAllDeposits() => Ok(depositsManager.GetAllDeposits());

        [HttpGet("/{id}")]
        public ActionResult<Deposit> GetDepositById(int id) => Ok(depositsManager.GetDepositById(id));

        [HttpGet("/{id}/calculate")]
        public ActionResult AccrualCalculation([FromRoute]int id, [FromQuery]CalculateDTO calculateDTO) => Ok(depositsManager.AccrualСalculation(id, calculateDTO));
    }
}
