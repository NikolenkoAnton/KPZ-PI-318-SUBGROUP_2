using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using App.Loans.Services;

namespace App.Loans.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        readonly LoansManager _valuesManager;
        readonly IValidateServices _validateService;
        public LoansController(
            IValidateServices validateService,
            LoansManager valuesManager)
        {
            _validateService = validateService;
            _valuesManager = valuesManager;
        }

        // GET api/loans/All
        [HttpGet("All")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return _valuesManager.GetValues().ToList();
        }
        
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> GetMoneyLeftByIdLoan(int id)
        {
            List<string> temp = new List<string>();
            _validateService.ValidateLoan(_valuesManager.GetItem(id));
            temp.Add(_valuesManager.GetMoneyLeft(id).ToString());
            var serviceCallResult = temp;
            return serviceCallResult;
        }
    }
}

