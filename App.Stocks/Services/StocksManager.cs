using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Configuration;
using App.Stocks.Exceptions;
using App.Stocks.Interfaces;
using App.Stocks.Models;
using Microsoft.Extensions.Logging;

namespace App.Stocks.Services {
    public class StocksManager : IStocksManager, ITransientDependency {
        private ICompaniesRepository repository;
        private ILogger<StocksManager> logger;

        public StocksManager (ICompaniesRepository repository, ILogger<StocksManager> logger) {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<IEnumerable<StockView>> CompanyStocks (int companyId) {

            logger.LogInformation ("Call CompanyStocks method");
            var company = await Task.Run (() => repository.CompanyById (companyId));

            if (company == null) {
                throw new EntityNotExistException (typeof (Company), companyId);
            }

            if (!company.IsOpenStocks) {
                throw new СompanyStocksIsPrivateException (company.Name, companyId);
            }

            List<StockView> stocksView = new List<StockView> ();

            foreach (var s in company.Stocks) {
                stocksView.Add (MappSingleStock (s, company));
            }

            return stocksView;
        }

        public async Task<StockView> CompanyStockByDate (int id, DateTime date) {

            logger.LogInformation ("Call CompanyStockByDate method");

            var company = await Task.Run (() => repository.CompanyById (id));

            if (company == null) {
                throw new EntityNotExistException (typeof (Company), id);
            }

            if (!company.IsOpenStocks) {
                throw new СompanyStocksIsPrivateException (company.Name, company.Id);
            }

            var stock = await Task.Run (() => company.Stocks.Where (el => el.CompareDate (date)).FirstOrDefault ());

            if (stock == null) {
                throw new IncorrectParamsFormatException ("Date");
            }

            var stockView = MappSingleStock (stock, company);

            return stockView;
        }

        private StockView MappSingleStock (Stock stock, Company company) {
            logger.LogInformation ("Call MappSingleStock method");

            return new StockView {
                Company = company.Name,
                    Cost = stock.Cost,
                    Date = stock.DateView
            };
        }
    }
}