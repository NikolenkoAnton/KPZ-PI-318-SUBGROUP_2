using System.Collections.Generic;
using System.Linq;
using App.Customers.Models;
using App.Customers.Services;
using Microsoft.AspNetCore.Mvc;
namespace App.Customers
{
    [Route("api/Customers")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private ICustomerManager manager;

        public CustomerController(ICustomerManager manager)
        {
            this.manager = manager;
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var actionResult = manager.GetById(id);
            return actionResult;
        }

        [HttpPost("{add}")]
        public ActionResult<Customer> Add([FromBody]Customer customer)
        {
            manager.Add(customer);
            return Ok();
        }
        [HttpPost("{edit}")]
        public void Edit(Customer customer)
        {
            manager.Edit(customer);
        }
        [HttpGet("all")]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
           
            return Ok(manager.GetCustomers());
        }

    }

}
