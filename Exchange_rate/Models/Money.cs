using System;
using System.Collections.Generic;
using System.Text;

namespace App.Exchange_rate.Models
{
    public class Money
    {
        private Dictionary<string, double> money;
        public Money()
        {

        }
       public void Addexchengeinnoneyquantity(string name, double quantity)
        {
            money.Add(name,quantity);
            
        }
        double Getexchengequantity(string name)
        {
            double result=0;
            foreach (var i in money)
            {
                if (i.Key==name)
                {
                    result = i.Value;
                }
            }

            return result;

        }
        void Changequantityexchenge(string name, double newquantity)
        {
            string tmp = null;
            foreach (var i in money)
            {
                if (i.Key == name)
                {
                    tmp = i.Key;
                    money.Remove(i.Key);
                    money.Add(tmp, newquantity);

                }
            }
        }
    }
}
