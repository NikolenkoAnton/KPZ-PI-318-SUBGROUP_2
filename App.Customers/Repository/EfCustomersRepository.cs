using App.Configuration;
using App.Customers.Models;
using App.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Customers.Repository
{
    public class EfCustomersRepository:ICustomerRepository,ITransientDependency
    {
        private readonly CustomersDBContext _dbContext;

        public EfCustomersRepository(CustomersDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Customer GetById(int id) => _dbContext.Customers.Where(x => x.Id == id).FirstOrDefault();

        public void Add(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }
        public void Edit(int id, Customer new_customer)
        {
            Customer customer = GetById(id);
            customer = new_customer;
            _dbContext.Customers.Update(customer);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _dbContext.Customers;
        }
       
        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
