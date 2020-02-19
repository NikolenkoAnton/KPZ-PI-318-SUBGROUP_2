using System;
using System.Collections.Generic;
using System.Text;

namespace App.Exchange_rate.Models
{
    public abstract class Exchanges
    {
        public string name;
        public double buy;
        public double sell;
        public Exchanges(string name, double buy, double sell)
        {
            this.name = name;
            this.buy = buy;
            this.sell = sell;
        }
        public void Addallnewparameters(string name, double buy, double sell)
        {
            this.name = name;
            this.buy = buy;
            this.sell = sell;
        }
        public string Getname() { return this.name; }
        public double Getbuycoast() { return this.buy; }
        public double Getsellcoast() { return this.sell; }
        public void Setname(string name) { this.name = name; }
        public void Setbuycoast(double buy) { this.buy = buy; }
        public void Setsellcoast(double sell) { this.sell = sell; }

    }
}
