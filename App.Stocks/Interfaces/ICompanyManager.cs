using App.Stocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Stocks.Interfaces
{
    public interface ICompaniesManager
    {
        Task<IEnumerable<CompanyView>> GetCompaniesWithOpenStocksAsync();

        Task<IEnumerable<CompanyView>> GetAllCompaniesAsync();

        Task<CompanyView> GetCompanyByIdAsync(int id);
    }
}
