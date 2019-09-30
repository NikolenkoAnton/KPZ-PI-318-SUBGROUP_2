using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Stocks.Models
{
    public class Company
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public bool IsAvailableToView { get; set; }
        public Stock[] Stocks { get; set; }

        public async Task<Stock> GetStockByDate(DateTime Date) => await Task.Run(() => Stocks.Where(st => st.CompareDate(Date)).FirstOrDefault());
        public Decimal GetStockCostByDate(DateTime date)
        {
            return Stocks.Where(stc => stc.CompareDate(date)).FirstOrDefault()?.Cost?? 0;

        }
        public decimal CurrentStocksPrice { get
            {

                var price = (from s in Stocks
                             orderby s.Date descending
                             select s);

                return price.FirstOrDefault().Cost;
            } }
    }

    public class CompanyView
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public decimal? CurrentStocksPrice { get; set; }

        public bool IsAvailableToView { get; set; }

    }

    
}