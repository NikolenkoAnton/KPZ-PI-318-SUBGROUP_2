using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Stocks.Interfaces;
using App.Stocks.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Stocks.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        readonly ICompaniesManager companyManager;
        readonly IStocksManager stocksManager;
        readonly ILogger<StocksController> logger;
        readonly IMapper mapper;
        public StocksController(
            ICompaniesManager companyManager,
            IStocksManager stocksManager,
            ILogger<StocksController> logger,
            IMapper mapper)
        {
            this.companyManager = companyManager;
            this.stocksManager = stocksManager;
            this.logger = logger;
            this.mapper = mapper;

        }

        [HttpGet("companies/{id}/stocks/all")] 
        public async Task<StocksListView> CompanyStocks(int id)
        {
            return await stocksManager.CompanyStocks(id);
        }

        [HttpGet("companies/{id}/stocks")]
        public async Task<StockView> StockByDate([FromQuery] string Date,int id)
        {
            return await stocksManager.CompanyStockByDate(id, DateTime.Parse(Date));
        }


        [HttpGet("companies/{id}")]
        public async Task<CompanyView> Company(int id)
        {
            return await companyManager.CompanyById(id);
        }
        [HttpGet("companies/open")]
        public async Task<IEnumerable<CompanyView>> AvailableCompanies()
        {
            return await companyManager.AvailableCompanies();
        }

        [HttpGet("companies/all")]
        public async Task<IEnumerable<CompanyView>> AllCompanies()
        {
           return await companyManager.AllCompanies();
           
        }
        //[HttpGet("companies/{id}")]
        //public async Task<Company> Company([FromRoute] int id)
        //{
        //    return await companyManager.CompanyById(id);
        //}
        

    }
}
