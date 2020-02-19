using System;
using System.Collections.Generic;
using System.Text;


namespace App.Exchange_rate.Models.Exchengemodels
{
    public class Cashier 
    {
        private string Name;
        private string Surname;
        private Money cashregister;
        private List<object> Exchangerate = new List<object>();

        public Cashier(string Name, string Surname, Money cashregister)
        {
            Add(Name,Surname, cashregister);
        }
        public void Add(string Name, string Surname, Money cashregister)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.cashregister= cashregister;
        }
        public void AddExchangeinlistrates (object exchenge)
        {
            Exchangerate.Add(exchenge);
        }
        public void Showallcontain() { }
        public string Getname() { return this.Name; }
        public string GetSurname() { return this.Surname; }
        public Money Getcashregistre() { return this.cashregister; }
        public void SetName(string Name) { this.Name= Name; }
        public void SetSurname(string Surname) { this.Surname = Surname; }
        public void SetCashregister(Money cashregister) { this.cashregister = cashregister; }
    }
}
