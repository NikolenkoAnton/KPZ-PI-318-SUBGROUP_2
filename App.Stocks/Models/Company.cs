using System.Collections.Generic;

namespace App.Stocks.Models
{
    public class Company
    {
        public int Id {get;set;}
        public string Name {get; set;}

        public string Description {get;set;}

        public string Photo {get;set;}

        public bool IsOpenStocks {get;set;}
        public IEnumerable<Stock> Stocks {get;set;}
    }
}