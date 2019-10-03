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
    public class CompaniesRepository : ICompaniesRepository, ITransientDependency
    {

        readonly IQueryable<Company> Companies;

        public CompaniesRepository()
        {
            Companies = CompaniesInitializer.InitCompanies();
        }
        public Company CompanyById(int id) => Companies.FirstOrDefault(comp => comp.Id == id);

        public IQueryable<Company> AllCompanies() => Companies;

        static class CompaniesInitializer
        {
            readonly static string[] companiesName = new string[] { "Amazon", "McDonald’s", "GE", "Samsung", "Apple", "Huawei", "LG", "KFC", "Coca-Cola" };

            private static IEnumerable<Stock> GenerateStocks()
            {
                Stock[] stocks = new Stock[7];

                for (int i = 0; i < 7; i++)
                {
                    stocks[i] = new Stock
                    {
                        Date = DateTime.Now.AddDays(i * -1),
                        Cost = new Random().Next(200 * i, 400 * i) + 470 * (i + 1)
                    };
                }
                return stocks;
            }
            public static IQueryable<Company> InitCompanies()
            {
                var companies = new Company[9];

                for (int i = 0; i < companies.Length; i++)
                {
                    var stocks = GenerateStocks();

                    var comp = new Company { Id = i + 1,
                        Name = companiesName[i],
                        Stocks = stocks.ToArray(),
                        Description = "BlaBla",
                        IsOpenStocks = i % 2 == 0 };

                    companies[i] = comp;
                }

                return companies.AsQueryable();
            }
        }

    }
}
