using App.Stocks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Stocks.Exceptions
{
    public class СompanyStocksIsPrivate : Exception
    {
        public string CompanyName { get; private set; }
        public СompanyStocksIsPrivate(string CompanyName){
            this.CompanyName = CompanyName;
        }

    }
}
