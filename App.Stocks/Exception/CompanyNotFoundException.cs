using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace App.Stocks.Exception
{
    public class CompanyNotFoundException : WebException
    {
        public CompanyNotFoundException(string message)
            :base(message)
        {

        }
    }
    public class CompanyNotAvailable : WebException
    {
        public CompanyNotAvailable(string message)
            :base(message)
        {

        }
    }
    public class StockNotFound : WebException
    {
        public StockNotFound(string message)
            : base(message)
        {

        }
    }

    public class DateException : WebException
    {
        public DateException(string message)
           : base(message)
        {

        }
    }
}
