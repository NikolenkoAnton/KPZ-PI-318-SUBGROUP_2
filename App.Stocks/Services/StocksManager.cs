using App.Configuration;
using App.Stocks.Exceptions;
using App.Stocks.Interfaces;
using App.Stocks.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Stocks.Services
{
    public class StocksManager : IStocksManager, ITransientDependency
    {
        private  ICompaniesRepository repository;

        private  IValidateServices validateServices;

        private ILogger<StocksManager> logger;

        public StocksManager(ICompaniesRepository repository,IValidateServices validateServices,ILogger<StocksManager> logger)
        {
            this.validateServices = validateServices;
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<IEnumerable<StockView>> CompanyStocks(int companyId)
        {
            logger.LogInformation("Call CompanyStocks method");
            var company = await Task.Run(() => repository.CompanyById(companyId));

            if (company == null)
            {
                throw new EntityNotExist(typeof(Company), $"Company with id :{companyId} doesn't exist!");
            }

            if (!company.IsOpenStocks)
            {
                throw new СompanyStocksIsPrivate(company.Name);
            }

            List<StockView> stocksView = new List<StockView>();
            
            foreach(var s in company.Stocks)
            {
                stocksView.Add(MappSingleStock(s, company));
            }

            return stocksView;
        }

        public async Task<StockView> CompanyStockByDate(int id, DateTime date)
        {
            logger.LogInformation("Call CompanyStockByDate method");

            var company = await Task.Run(() => repository.CompanyById(id));
           
            if( company == null)
            {
                throw new Exception($"Company with id {id} not found!");
            }

            var stock = await Task.Run(()=>company.Stocks.Where(el => el.CompareDate(date)).FirstOrDefault());

            validateServices.ValidateStocksCompany(stock, company, id);

            var stockView = MappSingleStock(stock, company);

            return stockView;
        }

        private StockView MappSingleStock(Stock stock, Company company)
        {
            logger.LogInformation("Call MappSingleStock method");

            return new StockView
            {
                Company = company.Name,
                Cost = stock.Cost,
                Date = stock.DateView
            };
        }
    }
}

