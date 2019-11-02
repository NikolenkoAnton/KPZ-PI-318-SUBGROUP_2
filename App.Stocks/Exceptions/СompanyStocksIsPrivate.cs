using System;
using System.Collections.Generic;
using System.Text;
using App.Stocks.Models;

namespace App.Stocks.Exceptions {
    public class СompanyStocksIsPrivateException : Exception {
        public string CompanyName { get; private set; }
        public int CompanyId { get; set; }
        public СompanyStocksIsPrivateException (string CompanyName, int CompanyId) {
            this.CompanyName = CompanyName;
            this.CompanyId = CompanyId;
        }

    }
}