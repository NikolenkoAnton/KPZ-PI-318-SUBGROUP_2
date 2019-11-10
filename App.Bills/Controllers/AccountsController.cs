using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using App.Accounts.Services;
using App.Accounts.Models;
using App.Accounts.Filters;
using Microsoft.Extensions.Logging;
using App.Accounts.Exceptions;
using App.Accounts.Inerfaces;

namespace App.Accounts.Controllers
{
    [Route("api/bills")]
    [ApiController]
    [TypeFilter(typeof(AccountsExceptionFilter), Arguments = new object[] { nameof(AccountsController) })]
    public class AccountsController : ControllerBase
    {
        readonly IAccountManager _valuesManager;
        readonly IValidateServices _validateService;
        readonly ILogger<AccountsController> logger;
        public AccountsController(
            IValidateServices validateService,
            AccountsManager valuesManager,
            ILogger<AccountsController> logger)
        {
            _validateService = validateService;
            _valuesManager = valuesManager;
            this.logger = logger;
        }

        [HttpGet("avaliableBills")]
        public ActionResult<IEnumerable<Account>> GetAvaliableBillsList()
        {
            logger.LogInformation("call GetAvaliableBillsList method");
            return _valuesManager.GetUnblockedBillsList().ToList();
        }
        [HttpGet("allBills")]
        public ActionResult<IEnumerable<Account>> GetAllBillsList()
        {
            logger.LogInformation("call GetAllBillsList method");
            return _valuesManager.GetAllBillsList().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetBillById(int id)
        {
            logger.LogInformation($"call GetBillById method with id = {id}");
            return _valuesManager.GetBillById(id);
        }

        [HttpPost("blockBill")]
        public Account BlockBill(int id)
        {
            logger.LogInformation($"call blockBill method with id = {id}");
            return _valuesManager.BlockBill(id);
        }

        [HttpPost("unblockBill")]
        public Account UnlockBill(int id)
        {
            logger.LogInformation($"call UnlockBill method with id = {id}");
            return _valuesManager.UnblockBill(id);
        }
    }
}

