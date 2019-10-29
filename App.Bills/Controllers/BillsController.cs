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
        public ActionResult<string> GetAvaliableBillsList()
        {
            string res = "";
            foreach(string s in _valuesManager.GetUnblockedBillsList().ToList())
            {
                res += s.ToString();
            }
            return res;
        }
        [HttpGet("allBills")]
        public ActionResult<string> GetAllBillsList()
        {
            string res = "";
            for (int i = 0; i <  _valuesManager.GetAllBillsList().ToList().Count(); i++)
            {
                res += _valuesManager.GetAllBillsList().ToList().ElementAt(i);
            }
            return res;
            
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetBillById(int id)
        {
            
            return _valuesManager.GetBillById(id);
        }

        [HttpPost("blockBill")]
        public string BlockBill(int id)
        {
            return _valuesManager.BlockBill(id);
        }

        [HttpPost("unblockBill")]
        public string UnlockBill(int id)
        {
            return _valuesManager.UnblockBill(id);
        }
    }
}

