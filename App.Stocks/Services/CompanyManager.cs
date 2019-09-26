using App.Configuration;
using App.Stocks.Interfaces;
using App.Stocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Stocks.Services
{
   public class CompaniesManager : ICompanyManager, ITransientDependency
    {
        private readonly IRepository repository;

        public CompaniesManager(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IQueryable<Company>> CompaniesWithOpenStocks() => await Task.Run(()=>repository.FilteredCompanies((comp => comp.IsOpenStocks)));

        public async Task<Company> CompanyById(int id)
        {
            var company = await Task.Run(() => repository.CompanyById(id));

            if(company == null)
            {
                //todo httpexception
            }
            if(company.IsOpenStocks)
            {

            }
            return company;
        }

        
    }
}
