using System;
using System.Collections.Generic;
using System.Text;

namespace App.Exchange_rate.Models.Exchengemodels
{
   public class Euro : Exchanges
    {
        public Euro(string name, double buy, double sell)
             : base(name, buy, sell)
        {

        }
    }
}
