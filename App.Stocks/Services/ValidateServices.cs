using App.Stocks.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace App.Stocks.Services
{
    public class ValidateServices : IValidateServices
    {

        public void ValidateCompany(Company company) 
        {

        }

        public void ValidateStock(Stock stock)
        {
        }

        public void ValidateStocksCompany(Stock stock, Company company)
        {
            ValidateCompany(company);
            ValidateStock(stock);
        }
        public void ValidateDate(DateTime Date)
        {
        }
    }

    public interface IValidateServices
    {
        void ValidateCompany(Company company);

        void ValidateDate(DateTime Date);

        void ValidateStock(Stock stock);

        void ValidateStocksCompany(Stock stock, Company company);

    }
}
