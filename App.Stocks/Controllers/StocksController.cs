using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Stocks.Exception;
using App.Stocks.Interfaces;
using App.Stocks.Models;
using App.Stocks.Services;
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
        readonly IValidateServices validateService;

        public StocksController(
            ICompaniesManager companyManager,
            IStocksManager stocksManager,
            ILogger<StocksController> logger,
            IMapper mapper,
            IValidateServices validateService)
        {
            this.companyManager = companyManager;
            this.stocksManager = stocksManager;
            this.logger = logger;
            this.mapper = mapper;
            this.validateService = validateService;

        }

        [HttpGet("companies/{id}/stocks/all")] 
        public async Task<StocksListView> CompanyStocks(int id)
        {
            return await stocksManager.CompanyStocks(id);
        }

        [HttpGet("companies/{id}/stocks")]
        public async Task<StockView> StockByDate([FromQuery] string date,int id)
        {
            try
            {
                var Date = DateTime.Parse(date);
                validateService.ValidateDate(Date);
                return await stocksManager.CompanyStockByDate(id, Date);

            }
            catch (FormatException)
            {
                throw new DateException("Incorrect parameter format!Correct date format - XX.XX.XXXX");
            }
            
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
        
        

    }
}
