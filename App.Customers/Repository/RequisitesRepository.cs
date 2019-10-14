using System;
using System.Collections.Generic;
using System.Text;
using App.Customers.Models;
namespace App.Customers.Repository
{
    public interface IRequisitesRepository
    {
        IEnumerable<Customer> GetAll();
        IEnumerable<string> GetValues();

        Customer Get(int id);
    }
}
