using App.Stocks.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Stocks.Interfaces
{
    public interface ICompaniesRepository
    {
        IQueryable<Company> AllCompanies();

        Company CompanyById(int id);
        IQueryable<Company> FilteredCompanies(Func<Company, Boolean> predicate);
    }
}