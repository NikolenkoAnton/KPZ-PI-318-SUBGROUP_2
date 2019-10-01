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
        private  IRepository repository;
        private  IValidateServices validateServices;


        public CompaniesManager(IRepository repository,IValidateServices validateServices)
        {
            this.validateServices = validateServices;
            this.repository = repository;
        }

        public async Task<IEnumerable<CompanyView>> AllCompanies() => await Task.Run(
                                            () => new List<CompanyView>());//mapper.Map<IEnumerable<CompanyView>>(repository.AllCompanies().ToList()) );
                                            

        public async Task<IEnumerable<CompanyView>> AvailableCompanies() => await Task.Run(
                                            () => new List<CompanyView>());//mapper.Map<IEnumerable<CompanyView>>(repository.FilteredCompanies(comp => comp.IsAvailableToView).ToList()));

        public async Task<CompanyView> CompanyById(int id)
        {

            var company = await Task.Run(() => repository.CompanyById(id));
            validateServices.ValidateCompany(company);

            return new CompanyView { };//mapper.Map<CompanyView>(company);
        }

       
    }
}
