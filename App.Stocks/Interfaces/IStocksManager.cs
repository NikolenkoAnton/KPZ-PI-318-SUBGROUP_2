using App.Stocks.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Stocks.Interfaces
{
    public interface IStocksManager
    {
        Task<IEnumerable<Stock>> CompanyStocks(int companyId);
        Task<IEnumerable<Stock>> CompanyStocksByDate(int companyId, DateTime date);
    }
}
