using System;
using System.Collections.Generic;
using System.Text;

namespace App.Exchange_rate.Models.Exchengemodels
{
    public class USADollar : Exchanges
    {
        public USADollar(string name, double buy, double sell)
            : base(name, buy, sell)
        {

        }
    }
}
