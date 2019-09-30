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

            if(!validateServices.ValidateCompany(company))
            {
                throw new Exception();
            }

            var Stocks = await Task.Run(() => mapper.Map<IEnumerable<StocksListItemView>>(company.Stocks));
            return new StocksListView { Company = company.Name, Stocks = Stocks };


        }

        public async Task<StockView> CompanyStockByDate(int companyId, DateTime date)
        {
            var company = await Task.Run(() => repository.CompanyById(companyId));

            if (!validateServices.ValidateCompany(company))
            {
                throw new Exception();
            }

            var stock = await Task.Run(()=>company.Stocks.Where(el => el.CompareDate(date)).FirstOrDefault());

            if(stock == null)
            {
                throw new Exception();
            }


            return await GetStockWithDifferencePrice(company, stock);

        }

        //private  decimal GetDifferencePrice(Stock stock, decimal cost)
        //{
        private decimal GetDiff(decimal curr, decimal other) => other == 0? other : curr - other;
        //}
        private async Task<StockView> GetStockWithDifferencePrice(Company company,Stock stock)
        {
            var stockView = await Task.Run(()=>mapper.Map<StockView>(stock));
            stockView.Company = company.Name;

            var currentStockDate = stock.Date;
            var currCost = stock.Cost;

            Task[] tasks = new Task[2]
            {
                 new Task(async () => {
                    var cost = await Task.Run(()=>company.GetStockCostByDate(currentStockDate.AddDays(1)));
                    stockView.DifferenceNextDay =  GetDiff(currCost,cost).ToString() + " $";
                    }),
                 new Task(async () =>{
                    var cost = await Task.Run(()=>company.GetStockCostByDate(currentStockDate.AddDays(-1)));

                    stockView.DifferencePrevDay =  GetDiff(currCost,cost).ToString() + " $";
                    })
            };

            foreach (var t in tasks)
                t.Start();

            Task.WaitAll(tasks);

            return stockView;
            //var prevStock = company.GetStocks
        }

       
    }
}

//companies, which has open stocks
//stocks any companies
//stocks any companies by date
