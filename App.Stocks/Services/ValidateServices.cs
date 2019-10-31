using App.Stocks.Exceptions;
using App.Stocks.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace App.Stocks.Services
{
    public class ValidateServices : IValidateServices
    {

        public void ValidateCompany(Company company, int CompanyId, bool IsOpenStocks = true)
        {
            if (company == null)
            {
                throw new EntityNotExist(typeof(Company),$"Company with id :{CompanyId} doesn't exist!");
            }
            if (!IsOpenStocks)
            {
                throw new СompanyStocksIsPrivate(company.Name);
            }
        }

        public void ValidateStock(Stock stock)
        {
            if (stock == null)
            {
                throw new EntityNotExist(typeof(Stock),"Stock doesn't exist!");
            }
        }

        public void ValidateStocksCompany(Stock stock, Company company, int CompanyId)
        {
            ValidateCompany(company, CompanyId, company?.IsOpenStocks ?? false);

            ValidateStock(stock);
        }
        public void ValidateDate(string Date)
        {
          
                var parsedDate = DateTime.Parse(Date);
                if (parsedDate.CompareTo(DateTime.Now) > 0)
                {
                    throw new IncorrectStockDate(parsedDate);
                }
            
            //catch(Exception e)
            //{
                
            //}
        }
    }
    public interface IValidateServices
    {
        void ValidateCompany(Company company, int CompanyId, bool IsOpenStocks);

        void ValidateDate(string Date);

        void ValidateStock(Stock stock);

        void ValidateStocksCompany(Stock stock, Company company, int CompanyId);

    }
}
