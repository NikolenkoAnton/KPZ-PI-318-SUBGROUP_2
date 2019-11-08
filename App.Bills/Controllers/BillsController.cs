using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using App.Bills.Services;
using App.Bills.Models;
using App.Bills.Filters;
using Microsoft.Extensions.Logging;
using App.Bills.Exceptions;

namespace App.Bills.Controllers
{
    [Route("api/bills")]
    [ApiController]
    [TypeFilter(typeof(BillsExceptionFilter), Arguments = new object[] { nameof(BillsController) })]
    public class BillsController : ControllerBase
    {
        readonly BillsManager _valuesManager;
        readonly IValidateServices _validateService;
        readonly ILogger<BillsController> logger;
        public BillsController(
            IValidateServices validateService,
            BillsManager valuesManager,
            ILogger<BillsController> logger)
        {
            _validateService = validateService;
            _valuesManager = valuesManager;
            this.logger = logger;
        }

        [HttpGet("avaliableBills")]
        public ActionResult<IEnumerable<Bill>> GetAvaliableBillsList()
        {
            logger.LogInformation("call GetAvaliableBillsList method");
            return _valuesManager.GetUnblockedBillsList().ToList();
        }
        [HttpGet("allBills")]
        public ActionResult<IEnumerable<Bill>> GetAllBillsList()
        {
            logger.LogInformation("call GetAllBillsList method");
            return _valuesManager.GetAllBillsList().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Bill> GetBillById(int id)
        {
            logger.LogInformation($"call GetBillById method with id = {id}");
            return _valuesManager.GetBillById(id);
        }

        [HttpPost("blockBill")]
        public Bill BlockBill(int id)
        {
            logger.LogInformation($"call blockBill method with id = {id}");
            return _valuesManager.BlockBill(id);
        }

        [HttpPost("unblockBill")]
        public Bill UnlockBill(int id)
        {
            logger.LogInformation($"call UnlockBill method with id = {id}");
            return _valuesManager.UnblockBill(id);
        }
    }
}

