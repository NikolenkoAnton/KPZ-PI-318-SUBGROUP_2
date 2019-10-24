using System;
using System.Collections.Generic;
using System.Text;

namespace App.Exchange_rate.Models.ModuleInterfaces
{
    public class Cashier : Imodelfunc
    {
        private string Name;
        private string Surname;
        private Money cashregister;
        public Cashier(string Name, string Surname, Money cashregister)
        {
            
        }
        public void Add(string Name, string Surname, Money cashregister)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.cashregister= cashregister;
        }
    }
}
