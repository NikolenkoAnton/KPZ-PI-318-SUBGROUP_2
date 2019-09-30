using App.Stocks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Stocks.Services
{
    public class ValidateServices : IValidateServices
    {

        public bool ValidateCompany(Company company) => company != null && company.IsAvailableToView;

        public bool ValidateStock(Stock stock) => stock != null;

        public bool ValidateStocksCompany(Stock stock, Company company) => ValidateCompany(company) && ValidateStock(stock);
    }

    public interface IValidateServices
    {
        bool ValidateCompany(Company company);

        bool ValidateStock(Stock stock);

        bool ValidateStocksCompany(Stock stock, Company company);

    }
}
