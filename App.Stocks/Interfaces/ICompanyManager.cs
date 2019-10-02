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
        Task<IEnumerable<CompanyView>> CompaniesWithOpenStocks();

        Task<IEnumerable<CompanyView>> AllCompanies();

        Task<CompanyView> CompanyById(int id);
    }
}
