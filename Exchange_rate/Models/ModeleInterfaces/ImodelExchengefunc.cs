using System;
using System.Collections.Generic;
using System.Text;

namespace App.Exchange_rate.Models.ModuleInterfaces
{
    public interface ImodelExchengefunc
    {


        void Add(string name,double buy, double sell);
        void Setname(string name);
        void Setbuycoast(double buy);
        void Setsellcoast(double sell);
        string Getname();
        double Getbuycoast();
        double Getsellcoast();


       

    }
}
