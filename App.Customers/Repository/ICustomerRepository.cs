using System;
using System.Linq;
using System.Collections.Generic;
using App.Customers.Models;
using App.Configuration;


namespace App.Customers.Repository
{
    public interface ICustomerRepository 
    {
        void Add(Customer customer);
        void Edit(int id,Customer new_customer);
        Customer GetById(int id);
        IEnumerable<Customer> GetCustomers();
    }

}
