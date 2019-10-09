using System;
using System.Collections.Generic;
using System.Text;
using App.Loans.Models;
using App.Configuration;
using App.Repositories;

namespace App.Loans.Repositories
{
    public interface ILoansRepository
    {
        IEnumerable<Loan> GetAll();
        IEnumerable<string> GetValues();

        Loan Get(int id);
    }
    public class LoansRepository : ILoansRepository, ITransientDependency
    {
        private Loan[] loans = { new Loan(10000, 10, 24), new Loan(28860, 3, 6), new Loan(5000, 0.01, 3) };
        string[] str = new string[3];
        public LoansRepository()
        {
            str[0] = loans[0].ToString();
            str[1] = loans[1].ToString();
            str[2] = loans[2].ToString();
        }
        public IEnumerable<Loan> GetAll()
        {
            return loans;
        }
        public IEnumerable<string> GetValues()
        {

            return str;
        }
        public Loan Get(int id)
        {
            return loans[id];
        }
    }
}
