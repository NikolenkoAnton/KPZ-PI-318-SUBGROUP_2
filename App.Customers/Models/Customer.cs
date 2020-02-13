using System;
using System.Collections.Generic;
using System.Text;

namespace App.Customers.Models
{
    public class Customer
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public long CardNumber { get; set; }

        public Customer(string surname, string name, long cardNumber)
        {
            this.Surname = surname;
            this.Name = name;
            this.CardNumber = cardNumber;
        }

        public Customer()
        {
        }


        // public void GetName(string name) => Name = name;
        // public void EditProp(CreditCard card) => Card = card;

        /*
        public void EditProp(CreditCard card ,string password)
        {
            this.Card = card;
            this.Password = password;
        }
        */
        // public override string ToString()
        // {
        //     return $"Surname:{Surname}, Name:{Name} "+ Card.ToString;
        // }
    }
}
