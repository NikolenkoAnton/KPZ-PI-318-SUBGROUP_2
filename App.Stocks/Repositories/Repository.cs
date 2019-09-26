using App.Configuration;
using App.Stocks.Interfaces;
using App.Stocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Stocks.Repositories
{
   public class Repository : IRepository, ITransientDependency
    {
        public IQueryable<Company> Companies { get; private set; }

        public Repository()
        {
            Companies = new List<Company>().AsQueryable();
                //new List<Company>();
        }

        public Company CompanyById(int id) => Companies.FirstOrDefault(comp => comp.Id == id && comp.IsOpenStocks);

        public IQueryable<Company> FilteredCompanies(Func<Company, bool> predicate) => Companies.Where(predicate).AsQueryable();
        

        //public Stock StockByDateAndCompanyId(DateTime date,int companyId) { }
        //public IQueryable<Stock> FilteredStocks(Func<Stock, bool> predicate) { }
    }
}
