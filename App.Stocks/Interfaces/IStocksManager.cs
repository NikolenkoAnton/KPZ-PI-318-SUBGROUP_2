using App.Stocks.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Stocks.Interfaces
{
    public interface IStocksManager
    {
        Task<IEnumerable<StockView>> CompanyStocks(int companyId);
        Task<StockView> CompanyStockByDate(int companyId, DateTime date);
    }
}
