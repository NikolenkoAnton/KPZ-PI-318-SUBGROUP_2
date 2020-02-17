using System.Collections.Generic;
using System.Linq;
using App.Customers.Exceptions;
using App.Customers.Models;
using App.Customers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Customers
{
    [Route("api/Customers")]
    [ApiController]
    [TypeFilter(typeof(CustomerExceptionFilter))]
    public class CustomerController : ControllerBase
    {
        readonly ILogger<CustomerController> _logger;
        
        private ICustomerManager _manager;

        public CustomerController(ICustomerManager manager,ILogger<CustomerController> logger)
        {
            this._manager = manager;
            this._logger = logger;
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            _logger.LogDebug("Get customer by id");
            var actionResult = _manager.GetById(id);
            return actionResult;
        }

        [HttpPost("{add}")]
        public ActionResult<Customer> Add([FromBody]Customer customer)
        {
            _logger.LogDebug("Add customer");
            _manager.Add(customer);
            return Ok();
        }
        [HttpPost("{edit}")]
        public void Edit(int id, Customer customer)

        {

            _logger.LogDebug("Edit customer");

            _manager.Edit(id, customer);

        }
        [HttpGet("all")]
        public IEnumerable<Customer> GetAll()
        {
            _logger.LogDebug("Get all customer");
            var result = _manager.GetCustomers().ToList();
            return result;
        }

    }

}
