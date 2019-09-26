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
    public class StocksManager : IStocksManager, ITransientDependency
    {
        private readonly IRepository repository;

        public StocksManager(IRepository repository)
        {
            this.repository = repository;
        }

        private void CompanyValidate(Company company)
        {
            if (company == null)
            {

            }
            if (!company.IsOpenStocks)
            {

            }
        }
        public async Task<IEnumerable<Stock>> CompanyStocks(int companyId)
        {
            var company = await Task.Run(() => repository.CompanyById(companyId));

            CompanyValidate(company);
            return company.Stocks;
        }
       
        public async Task<IEnumerable<Stock>> CompanyStocksByDate(int companyId, DateTime date)
        {
            var company = await Task.Run(() => repository.CompanyById(companyId));

            CompanyValidate(company);

            //var b = company.Stocks.Where(stock => DateTime.Compare(stock.Date, date));
            var stock = await Task.Run(()=>company.Stocks.Where(el => DateTime.Compare(el.Date, date)==0));

            if(stock == null)
            {

            }
            return stock;
        }
    }
}

//companies, which has open stocks
//stocks any companies
//stocks any companies by date
