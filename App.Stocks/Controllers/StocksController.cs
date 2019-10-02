using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Stocks.Interfaces;
using App.Stocks.Models;
using App.Stocks.Services;
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
        readonly IValidateServices validateService;

        public StocksController(
            ICompaniesManager companyManager,
            IStocksManager stocksManager,
            IValidateServices validateService)
        {
            this.companyManager = companyManager;
            this.stocksManager = stocksManager;
            this.validateService = validateService;

        }

        [HttpGet("companies/{id}/stocks/all")] 
        public async Task<IEnumerable<StockView>> CompanyStocks(int id)
        {
            return await stocksManager.CompanyStocks(id);
        }

        [HttpGet("companies/{id}/stocks")]
        public async Task<StockView> StockByDate([FromQuery] string Date,int id)
        {
            validateService.ValidateDate(Date);
            return await stocksManager.CompanyStockByDate(id, DateTime.Parse(Date));
        }

        [HttpGet("companies/{id}")]
        public async Task<CompanyView> Company(int id)
        {
            return await companyManager.CompanyById(id);
        }

        [HttpGet("companies/open")]
        public async Task<IEnumerable<CompanyView>> CompaniesWithOpenStocks()
        {
            return await companyManager.CompaniesWithOpenStocks();
        }

        [HttpGet("companies/all")]
        public async Task<IEnumerable<CompanyView>> AllCompanies()
        {
           return await companyManager.AllCompanies();
           
        }
        
        

    }
}
