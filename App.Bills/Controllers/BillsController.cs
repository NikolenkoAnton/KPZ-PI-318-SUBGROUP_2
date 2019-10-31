using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using App.Bills.Services;
using App.Bills.Models;

namespace App.Bills.Controllers
{
    [Route("api/bills")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        readonly BillsManager _valuesManager;
        readonly IValidateServices _validateService;
        public BillsController(
            IValidateServices validateService,
            BillsManager valuesManager)
        {
            _validateService = validateService;
            _valuesManager = valuesManager;
        }

        [HttpGet("avaliableBills")]
        public ActionResult<IEnumerable<Bill>> GetAvaliableBillsList()
        {
            return _valuesManager.GetUnblockedBillsList().ToList();
        }
        [HttpGet("allBills")]
        public ActionResult<IEnumerable<Bill>> GetAllBillsList()
        {
            return _valuesManager.GetAllBillsList().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Bill> GetBillById(int id)
        {
            
            return _valuesManager.GetBillById(id);
        }

        [HttpPost("blockBill")]
        public Bill BlockBill(int id)
        {
            return _valuesManager.BlockBill(id);
        }

        [HttpPost("unblockBill")]
        public Bill UnlockBill(int id)
        {
            return _valuesManager.UnblockBill(id);
        }
    }
}

