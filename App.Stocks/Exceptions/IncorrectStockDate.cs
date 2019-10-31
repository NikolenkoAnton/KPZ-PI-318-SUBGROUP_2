using System;
using System.Collections.Generic;
using System.Text;

namespace App.Stocks.Exceptions
{
    public class IncorrectStockDate : Exception
    {
        public DateTime InccorectDate { get; private set; }

        public IncorrectStockDate(DateTime InccorectDate) {

            this.InccorectDate = InccorectDate;
        }

    }
}
