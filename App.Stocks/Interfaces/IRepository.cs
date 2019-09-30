using App.Stocks.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Stocks.Interfaces
{
    public interface IRepository
    {
        IQueryable<Company> Companies { get; }

        Company CompanyById(int id);
        //IQueryable<Company> AllCompanies();

         //IQueryable<Stock> CompaniesStocks(int companyId);

        IQueryable<Company> FilteredCompanies(Func<Company, Boolean> predicate);
    }
}