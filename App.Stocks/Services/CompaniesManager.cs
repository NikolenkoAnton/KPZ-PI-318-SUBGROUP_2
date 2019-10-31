using App.Configuration;
using App.Stocks.Interfaces;
using App.Stocks.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Stocks.Services
{
    public class CompaniesManager : ICompaniesManager, ITransientDependency
    {
        private ICompaniesRepository repository;

        private ILogger<CompaniesManager> logger;
        public CompaniesManager(ICompaniesRepository repository, ILogger<CompaniesManager> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<IEnumerable<CompanyView>> GetAllCompaniesAsync()
        {
            logger.LogInformation("Call GetAllCompaniesAsync method");

            var companies = await Task.Run(() => repository.AllCompanies().ToList());

            List<CompanyView> companyViews = new List<CompanyView>();

            foreach (var c in companies)
            {
                companyViews.Add(MappSingleCompany(c));
            }
            return companyViews;
        }

        public async Task<IEnumerable<CompanyView>> GetCompaniesWithOpenStocksAsync()
        {
            logger.LogInformation("Call GetCompaniesWithOpenStocksAsync method");

            var companies = await Task.Run(() => repository.AllCompanies().Where(comp => comp.IsOpenStocks).ToList());

            List<CompanyView> companyViews = new List<CompanyView>();

            foreach (var c in companies)
            {
                companyViews.Add(MappSingleCompany(c));
            }
            return companyViews;
        }

        public async Task<CompanyView> GetCompanyByIdAsync(int id)
        {
            logger.LogInformation("Call GetCompanyByIdAsync method");

            var company = await Task.Run(() => repository.CompanyById(id));

            if (company == null)
            {
                return null;
            }

            return MappSingleCompany(company);
        }

        private CompanyView MappSingleCompany(Company company)
        {
            logger.LogInformation("Call MappSingleCompany method");

            return new CompanyView
            {
                Id = company.Id,
                Name = company.Name,
                Description = company.Description,
                Photo = company.Photo,
                IsOpenStocks = company.IsOpenStocks
            };
        }
    }
}
