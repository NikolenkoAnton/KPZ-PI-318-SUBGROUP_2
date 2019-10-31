using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App.Stocks.Exceptions;
using App.Stocks.Filters;
using App.Stocks.Interfaces;
using App.Stocks.Models;
using App.Stocks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Stocks.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    [TypeFilter(typeof(StockExceptionFilter), Arguments = new object[] { nameof(StocksController) })]
    public class StocksController : ControllerBase
    {
        readonly ICompaniesManager companyManager;
        readonly IStocksManager stocksManager;
        readonly IValidateServices validateService;
        readonly ILogger<StocksController> logger;
        public StocksController(
            ICompaniesManager companyManager,
            IStocksManager stocksManager,
            IValidateServices validateService,
            ILogger<StocksController> logger)
        {
            this.companyManager = companyManager;
            this.stocksManager = stocksManager;
            this.validateService = validateService;
            this.logger = logger;

        }

        [HttpGet("companies/{id}/stocks/all")] 
        public async Task<IEnumerable<StockView>> CompanyStocks(int id)
        {
            logger.LogInformation($"Call CompanyStocks method with id : {id}");
            return await stocksManager.CompanyStocks(id);
        }
        [HttpGet("companies/{id}/stocks")]
        public async Task<StockView> StockByDate([FromQuery] string Date,int id)
        {
            logger.LogInformation($"Call StockByDate with id : {id} , date: {Date}");
            validateService.ValidateDate(Date);
            return await stocksManager.CompanyStockByDate(id, DateTime.Parse(Date));
        }

        [HttpGet("companies/{id}")]
        public async Task<CompanyView> Company(int id)
        {
            logger.LogInformation($"Call Company(by id) with id : {id}");
            var company = await companyManager.GetCompanyByIdAsync(id);
            if(company == null)
            {
                throw new EntityNotExist(typeof(Company), "Company doesn't exist");
            }
            return company;
        }

        [HttpGet("companies/open")]
        public async Task<IEnumerable<CompanyView>> CompaniesWithOpenStocks()
        {
            logger.LogInformation($"Call CompaniesWithOpenStocks");
            return await companyManager.GetCompaniesWithOpenStocksAsync();
        }

        [HttpGet("companies/all")]
        public async Task<IEnumerable<CompanyView>> AllCompanies()
        {
            logger.LogInformation($"Call AllCompanies");
            return await companyManager.GetAllCompaniesAsync();
        }
        
        

    }
}
