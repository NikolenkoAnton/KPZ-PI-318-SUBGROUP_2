using System;
using System.Collections.Generic;
using System.Text;

namespace App.Stocks.Models
{
    public class CompanyView
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public bool IsOpenStocks { get; set; }

    }
}
