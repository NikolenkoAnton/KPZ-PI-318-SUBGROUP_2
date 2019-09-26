using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Stocks.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Stocks.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        readonly ICompanyManager companyManager;
        readonly IStocksManager stocksManager;
        readonly ILogger<StocksController> logger;
        public StocksController(
            ICompanyManager companyManager,
            IStocksManager stocksManager,
            ILogger<StocksController> logger)
        {
            this.companyManager = companyManager;
            this.stocksManager = stocksManager;
            this.logger = logger;

        }

       [HttpGet]
       public async Task<IActionResult> StockByDate([FromQuery] string Date, [FromQuery] int companyId)
       {
            return null;
       }

        [HttpGet("companies")]
        public async Task<IActionResult> OpenCompanies()
        {
            return null;
            //return await companyManager;
        }
        [HttpGet("companies/{id}")]
        public async Task<IActionResult> Company([FromQuery] string Date)
        {
            return null;
        }
        

    }
}
