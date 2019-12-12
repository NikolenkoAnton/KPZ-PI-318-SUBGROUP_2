using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using App.Loans.Services;
using Microsoft.Extensions.Logging;
using App.Loans.Filters;
using App.Loans.Models;

namespace App.Loans.Controllers
{
    [TypeFilter(typeof(LoansExceptionsFilter), Arguments = new object[] { nameof(LoansController) })]
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        readonly LoansManager _valuesManager;
        readonly IValidateServices _validateService;
        readonly ILogger<LoansController> _logger;

        public LoansController(
            IValidateServices validateService,
            LoansManager valuesManager,
            ILogger<LoansController> logger)
        {
            _validateService = validateService;
            _valuesManager = valuesManager;
            _logger = logger;
        }

        [HttpGet("All")]
        public ActionResult<IEnumerable<Loan>> GetActiveLoansList()
        {
            _logger.LogInformation("call GetActiveLoansList method");
            return _valuesManager.GetListActiveLoans().ToList();
        }
        
        [HttpGet("{id}")]
        public ActionResult<string> GetMoneyLeftByIdLoan(int id)
        {
            _logger.LogInformation($"call GetMoneyLeftByIdLoan method with id = {id}");
            _validateService.ValidateLoan(_valuesManager.GetItem(id));
            var serviceCallResult = _valuesManager.GetMoneyLeft(id).ToString();
            return serviceCallResult;
        }
    }
}

