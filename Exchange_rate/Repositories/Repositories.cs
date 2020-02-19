using System;
using System.Collections.Generic;
using System.Text;
using App.Exchange_rate.Models.ModuleInterfaces;
using App.Exchange_rate.Models.Exchengemodels;
using App.Exchange_rate.Models;
namespace App.Exchange_rate.Repositories
{
    class Repositories
    {

        private British_Pound british_pound;
        private USADollar uSADollar;
        private Euro euro;
        private Japanise_Yen japanise_Yen;
        private Money monyyincase;
        private Money moneyinpurse;
        private Order order;
        private Cashier cashier;
        public Repositories()
        {

            string name;
            double buy, sell;
            name = "British_Pound";
            buy = 30.5;
            sell = 31.4;
            this. british_pound = new British_Pound(name,buy,sell);
            name = "USADollar";
            buy = 24.05;
            sell = 24.54;
            this. uSADollar = new USADollar(name, buy, sell);
            name = "Euro";
            buy = 26.5;
            sell = 27.54;
            this. euro = new Euro(name, buy, sell);
            name = "Japanise_Yen";
            buy = 18.9;
            sell = 19.56;
            this. japanise_Yen = new Japanise_Yen(name, buy, sell);

            this. monyyincase = new Money();
            monyyincase.Addexchengeinnoneyquantity(british_pound.name,50.8);
            monyyincase.Addexchengeinnoneyquantity(uSADollar.name, 500.8);
            monyyincase.Addexchengeinnoneyquantity(euro.name, 5350.28);
            monyyincase.Addexchengeinnoneyquantity(japanise_Yen.name, 100.8);
            this. moneyinpurse = new Money();
            moneyinpurse.Addexchengeinnoneyquantity(british_pound.name, 1000);
            moneyinpurse.Addexchengeinnoneyquantity(uSADollar.name, 10000);
            moneyinpurse.Addexchengeinnoneyquantity(euro.name, 5000);
            moneyinpurse.Addexchengeinnoneyquantity(japanise_Yen.name, 3000);
            this. order = new Order("Bogdan","Savenko", moneyinpurse);
            this. cashier = new Cashier("Andrew", "WHils", monyyincase);
            cashier.AddExchangeinlistrates(british_pound);
            cashier.AddExchangeinlistrates(uSADollar);
            cashier.AddExchangeinlistrates(euro);
            cashier.AddExchangeinlistrates(japanise_Yen);
        }
        public British_Pound GetBritishpound() 
        {
            return this.british_pound;
        }
        public USADollar GetUSADollar()
        {
            return this.uSADollar;
        }
        public Euro GetEuro()
        {
            return this.euro;
        }
        public Japanise_Yen GetJapanise_Yen()
        {
            return this.japanise_Yen;
        }
        public Money GetMoneymonyyincase()
        {
            return this.monyyincase;
        }
        public Money GetMoneymoneyinpurse()
        {
            return this.moneyinpurse;
        }
        public Order GetOrder()
        {
            return this.order;
        }
        public Cashier GetCashier()
        {
            return this.cashier;
        }
    }
}
