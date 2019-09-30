using App.Configuration;
using App.Stocks.Interfaces;
using App.Stocks.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Stocks.Services
{
    public class StocksManager : IStocksManager, ITransientDependency
    {
        private  IRepository repository;

        private  IMapper mapper;

        private  IValidateServices validateServices;


        public StocksManager(IRepository repository,IMapper mapper, IValidateServices validateServices)
        {
            this.mapper = mapper;
            this.validateServices = validateServices;
            this.repository = repository;
        }

        public async Task<StocksListView> CompanyStocks(int companyId)
        {

            var company = await Task.Run(() => repository.CompanyById(companyId));

            validateServices.ValidateCompany(company);

            var stocks = await Task.Run(() => mapper.Map<IEnumerable<StocksListItemView>>(company.Stocks));

            
            return new StocksListView { Company = company.Name, Stocks = stocks };


        }

        public async Task<StockView> CompanyStockByDate(int companyId, DateTime date)
        {
            var company = await Task.Run(() => repository.CompanyById(companyId));

           
            var stock = await Task.Run(()=>company.Stocks.Where(el => el.CompareDate(date)).FirstOrDefault());

            validateServices.ValidateStocksCompany(stock, company);

            var prevStock = await Task.Run(() => company.GetStockByDate(stock.Date.AddDays(-1)));

            var nextStock = await Task.Run(() => company.GetStockByDate(stock.Date.AddDays(1)));

            var stockView = await Task.Run(() => mapper.Map<StockView>(stock));

            stockView.SetPriceDifference(prevStock);
            stockView.SetPriceDifference(nextStock);

            if (stockView.DifferenceNextDay == null) stockView.DifferenceNextDay = "0";

            if (stockView.DifferencePrevDay == null) stockView.DifferencePrevDay = "0";

            return stockView;

        }


        //private decimal GetDiff(decimal curr, decimal other) => other == 0? other : curr - other;
        //private async Task<StockView> GetStockWithDifferencePrice(Company company,Stock stock)
        //{
        //    var stockView = await Task.Run(()=>mapper.Map<StockView>(stock));
        //    stockView.Company = company.Name;

        //    var currentStockDate = stock.Date;
        //    var currCost = stock.Cost;

        //    Task[] tasks = new Task[2]
        //    {
        //         new Task(async () => {
        //            var cost = await Task.Run(()=>company.GetStockCostByDate(currentStockDate.AddDays(1)));
        //            stockView.DifferenceNextDay =  GetDiff(currCost,cost).ToString() + " $";
        //            }),
        //         new Task(async () =>{
        //            var cost = await Task.Run(()=>company.GetStockCostByDate(currentStockDate.AddDays(-1)));

        //            stockView.DifferencePrevDay =  GetDiff(currCost,cost).ToString() + " $";
        //            })
        //    };

        //    foreach (var t in tasks)
        //        t.Start();

        //    Task.WaitAll(tasks);

        //    return stockView;
        //}

       
    }
}

