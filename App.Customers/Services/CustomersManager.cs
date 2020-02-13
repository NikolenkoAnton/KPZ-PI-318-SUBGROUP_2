using System;
using System.Collections.Generic;
using System.Text;
using App.Customers.Repository;
using App.Customers.Models;
using App.Repositories;
using App.Configuration;
using Microsoft.Extensions.Logging;
using App.Customers.Exceptions;

namespace App.Customers.Services
{
    public interface ICustomerManager
    {
        void Add(Customer customer);
        void Edit(Customer customer);
        Customer GetById(int id);
        IEnumerable<Customer> GetCustomers();
    }

    public class CustomerManager : ICustomerManager,ITransientDependency
    {
        readonly ICustomerRepository irepository;
        private readonly ILogger<CustomerManager> logger;

        public CustomerManager(ICustomerRepository repository,ILogger<CustomerManager> logger)
        {
            irepository = repository;
            this.logger = logger;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return irepository.GetCustomers();
        }

        public void Add(Customer customer)
        {
            logger.LogDebug($"methodAdd");
            foreach (Customer person in CustomerRepository.customers)
                if (customer.CardNumber == person.CardNumber)
                    throw new EntityUniqueCardExceptions(person.CardNumber);
            irepository.Add(customer);
        }
        
        public Customer GetById(int id)
        {
            logger.LogDebug($"methodGetById");
            if (irepository.GetById(id) == null)
                throw new EntityNotFoundException(typeof(Customer));
            return irepository.GetById(id);
        }

        public void Edit(Customer customer)
        {
            logger.LogDebug($"methodEdit");
            if (customer.CardNumber <= 0)
                throw new EntityNotFoundException(typeof(Customer));
            irepository.Edit(customer);
        }
    }


}
