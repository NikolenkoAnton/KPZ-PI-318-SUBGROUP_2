using System.Linq;
using App.Configuration;
using App.Stocks.Interfaces;
using App.Stocks.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Stocks
{
    public class CompaniesEFRepository : ICompaniesRepository, ITransientDependency
    {
        private readonly StocksDBContext _stockDbContext;
        public CompaniesEFRepository(StocksDBContext stockDbContext)
        {
            _stockDbContext = stockDbContext;
        }
        public IQueryable<Company> AllCompanies() => _stockDbContext.Companies;
        public Company CompanyById(int id) => _stockDbContext.Companies.Where(c => c.Id == id).FirstOrDefault();
    }
}