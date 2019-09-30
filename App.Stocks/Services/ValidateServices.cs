using App.Stocks.Exception;
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

            if (company == null)
                throw new CompanyNotFoundException("Company doesn't exist!");

            if (!company.IsAvailableToView)
                throw new CompanyNotAvailable("Company isn't public!You can't see detail information.");
        }

        public void ValidateStock(Stock stock)
        {
           if(stock == null)
                throw new CompanyNotFoundException("Information about stock on this date doesn't exist!");

        }

        public void ValidateStocksCompany(Stock stock, Company company)
        {
            ValidateCompany(company);
            ValidateStock(stock);
        }
        public void ValidateDate(DateTime Date)
        {
            if (Date.CompareTo(DateTime.Now) > 0) throw new DateException("Incorrect date!");
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
