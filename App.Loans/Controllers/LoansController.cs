using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using App.Loans.Services;

namespace App.Loans.Controllers
{
    /// <summary>
    /// This is example controller
    /// IMPORTANT the route to your won module should be 'api/{yourModuleName}' in order to avoid conflicts with other modules
    /// </summary>
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        readonly ILogger<LoansController> _logger;
        readonly LoansManager _valuesManager;
        readonly IValidateServices _validateService;
        public LoansController(
            IValidateServices validateService,
            ILogger<LoansController> logger,
            LoansManager valuesManager)
        {
            _validateService = validateService;
            _logger = logger;
            _valuesManager = valuesManager;
        }

        // GET api/loans/All
        [HttpGet("All")]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInformation("NOTHING");
            return _valuesManager.GetValues().ToList();
        }
        
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get_money_left_by_id_Loan(int id)
        {
            List<string> temp = new List<string>();
            _validateService.ValidateLoan(_valuesManager.GetItem(id));
            temp.Add(_valuesManager.Get_money_left(id).ToString());
            var serviceCallResult = temp;
            return serviceCallResult;
        }
    }
}

