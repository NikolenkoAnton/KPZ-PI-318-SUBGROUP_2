using App.Configuration;
using App.Stocks.Interfaces;
using App.Stocks.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private  IMapper mapper;
        private  IValidateServices validateServices;


        public CompaniesManager(IRepository repository, IMapper mapper, IValidateServices validateServices)
        {
            this.mapper = mapper;
            this.validateServices = validateServices;
            this.repository = repository;
        }

        public async Task<IEnumerable<CompanyView>> AllCompanies() => await Task.Run(
                                            () => mapper.Map<IEnumerable<CompanyView>>(repository.AllCompanies().ToList()) );
                                            

        public async Task<IEnumerable<CompanyView>> AvailableCompanies() => await Task.Run(
                                            () => mapper.Map<IEnumerable<CompanyView>>(repository.FilteredCompanies(comp => comp.IsAvailableToView).ToList()));

        public async Task<CompanyView> CompanyById(int id)
        {

            var company = await Task.Run(() => repository.CompanyById(id));
            validateServices.ValidateCompany(company);

            return mapper.Map<CompanyView>(company);
        }

       
    }
}
