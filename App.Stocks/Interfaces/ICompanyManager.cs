using App.Stocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Stocks.Interfaces
{
    public interface ICompanyManager
    {
         Task<IQueryable<Company>> CompaniesWithOpenStocks();
         Task<Company> CompanyById(int id);
    }
}
