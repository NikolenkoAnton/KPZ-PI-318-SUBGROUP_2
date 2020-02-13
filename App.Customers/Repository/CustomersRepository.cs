using System;
using System.Linq;
using System.Collections.Generic;
using App.Customers.Models;
using App.Customers.Repository;
using App.Repositories;
using App.Configuration;

namespace App.Customers.Repository
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Edit(Customer customer);
        Customer GetById(int id);
        IEnumerable<Customer> GetCustomers();
    }

    public class CustomerRepository : ICustomerRepository, ITransientDependency
    {
        public static List<Customer> customers = new List<Customer>();

        static CustomerRepository()
        {
            customers.Add(new Customer() { Surname = "Andei ", Name = " Vuhohol", CardNumber = 9796785587575 });
            customers.Add(new Customer() { Surname="Aleksandr", Name="Svoi", CardNumber = 9796785587576 });
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


        public IEnumerable<Customer> GetCustomers()
        {
            return customers;
        }
    }

}
