using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public LoansController(

            ILogger<LoansController> logger,
            LoansManager valuesManager)
        {

            _logger = logger;
            _valuesManager = valuesManager;
        }

        // GET api/example/values
        [HttpGet("loans/all")]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            var serviceCallResult = _valuesManager.GetValues().ToList();
            return serviceCallResult;
        }
        [HttpGet("loans/{id}")]
        public ActionResult<IEnumerable<string>> Get_money_left_by_id_Loan(int id)
        {
            List<string> temp = new List<string>();
            temp.Add(_valuesManager.Get_money_left(id).ToString());
            var serviceCallResult = temp;
            return serviceCallResult;
        }
    }
}

