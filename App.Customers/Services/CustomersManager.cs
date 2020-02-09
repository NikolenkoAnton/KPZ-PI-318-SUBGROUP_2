using System.Collections.Generic;
using App.Customers.Repository;
using App.Customers.Models;
using App.Configuration;

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

        public CustomerManager(ICustomerRepository repository)
        {
            irepository = repository;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return irepository.GetCustomers();
        }

        public void Add(Customer customer)
        {
            irepository.Add(customer);
        }
        
        public Customer GetById(int id)
        {
            return irepository.GetById(id);
        }

        public void Edit(Customer customer)
        {
            irepository.Edit(customer);
        }
    }


}
