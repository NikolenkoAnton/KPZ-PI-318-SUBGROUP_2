using System.Collections.Generic;
using App.Configuration;
using App.Customers.Models;

namespace App.Customers.Repository
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Edit(Customer customer);
        Customer GetById(int id);
        IEnumerable<Customer> GetCustomers();
    }

    public class CustomerRepository : ICustomerRepository,ITransientDependency
    {
        static List<Customer> customers = new List<Customer>();

        static CustomerRepository()
        {
            customers.Add(new Customer() { Surname = " Surname", Name = " Name", CardNumber = 9796785587575 });
        }



        public Customer GetById(int id)
        {
            return customers[id];
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public void Edit(Customer customer)
        {
            foreach (Customer obj in customers)
            {
                if (obj.CardNumber == customer.CardNumber)
                {
                    customers[customers.IndexOf(obj)] = customer;
                }
            }
        }


        public IEnumerable<Customer> GetCustomers() => customers;
    }

}
