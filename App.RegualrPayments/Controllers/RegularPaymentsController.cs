using Microsoft.AspNetCore.Mvc;
using App.RegularPayments.Interfaces;
using App.RegularPayments.Models;

namespace App.RegularPayments.Controllers
{
    [Route("api/RegularPayments")]
    [ApiController]
    public class RegularPaymentsController : ControllerBase
    {
        private IRegularPaymentsManager manager;
        public RegularPaymentsController(IRegularPaymentsManager manager)
        {
            this.manager = manager;
        }

        [HttpGet("{id}")]
        public ActionResult<RegularPayment> Get(int id)
        {
            var actionResult = manager.GetPayment(id);
            return actionResult;
        }

        [HttpGet]
        public ActionResult<RegularPayment> GetNext()
        {
            var actionResult = manager.GetNext();
            return actionResult;
        }
        [HttpPost("add")]
        public ActionResult Add([FromBody]RegularPayment payment)
        {
            manager.AddPayment(payment);
            return Ok();
        }

    }
}
