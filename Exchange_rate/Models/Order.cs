using System;
using System.Collections.Generic;
using System.Text;

namespace App.Exchange_rate.Models
{
    class Order
    {
        private string Name;
        private string Surname;
        private Money cash;
        public Order(string Name, string Surname, Money cash)
        {
            Add(Name, Surname, cash);
        }
        public void Add(string Name, string Surname, Money cash)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.cash = cash;
        }
        public void Showallcontain() { }
        public string Getname() { return this.Name; }
        public string GetSurname() { return this.Surname; }
        public Money Getcashregistre() { return this.cash; }
        public void SetName(string Name) { this.Name = Name; }
        public void SetSurname(string Surname) { this.Surname = Surname; }
        public void SetCashregister(Money cashregister) { this.cash = cashregister; }
    }
}
