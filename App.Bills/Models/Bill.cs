using System;
using System.Collections.Generic;
using System.Text;

namespace App.Bills.Models
{
    public class Bill
    {
        
        public double money { get; set; }//деньги на счету
        public string Name { get; set; }//Имя владельца счета
        public string Surname { get; set; }//Фамилия владельца счета
        public bool IsBlocked { get; set; }//Заблокирован ли счет

        public Bill(double money, string Name, string Surname)
        {
            this.money = money;
            this.Name = Name;
            this.Surname = Surname;
            IsBlocked = false;
        }

        public override string ToString()
        {
            return "Bill info. \nBill owner:" + Name + " " + Surname + ".\n" + "Fmount of money: " + money + ".\n"+"Bill is blocked:"+ IsBlocked + "\n \n";
        }
    }
}
