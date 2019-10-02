using App.Configuration;
using App.Stocks.Interfaces;
using App.Stocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Stocks.Services
{
   public class CompaniesManager : ICompaniesManager, ITransientDependency
    {
        private  ICompaniesRepository repository;
        public CompaniesManager(ICompaniesRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<CompanyView>> AllCompanies()
        {

            var companies = await Task.Run(()=>repository.AllCompanies().ToList());

            List<CompanyView> companyViews = new List<CompanyView>();

            foreach(var c in companies)
            {
                companyViews.Add(MappSingleCompany(c));
            }
            return companyViews;
        }
                                            
        public async Task<IEnumerable<CompanyView>> CompaniesWithOpenStocks()
        {
            var companies = await Task.Run(()=>repository.FilteredCompanies(x => x.IsOpenStocks));

            List<CompanyView> companyViews = new List<CompanyView>();

            foreach (var c in companies)
            {
                companyViews.Add(MappSingleCompany(c));
            }
            return companyViews;
        }

        public async Task<CompanyView> CompanyById(int id)
        {
            var company = await Task.Run(() => repository.CompanyById(id));

            return MappSingleCompany(company);
        }

        private CompanyView MappSingleCompany(Company company) =>
            new CompanyView
            {
                Id = company.Id,
                Name = company.Name,
                Description = company.Description,
                Photo = company.Photo,
                IsOpenStocks = company.IsOpenStocks
            };
        
    }
}
