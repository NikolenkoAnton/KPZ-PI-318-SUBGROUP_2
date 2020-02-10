using System;
using System.Collections.Generic;
using System.Text;

namespace App.Customers.Models
{
    public class Prop
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public CreditCard Card { get; set; } = new CreditCard();

       public Prop(string surname, string name, string password, CreditCard card)
        {
            this.Surname = surname;
            this.Name = name;
            this.Password = password;
            this.card = card;
        }

        public void EditProp(CreditCard card) => Card = card;

        public void EditProp(string password) => Password = password;

        public void EditProp(CreditCard card,string password)
        {
            this.Card = card;
            this.Password = card;
        }
        public override string ToString()
        {
            return $"Surname:{Surname}, Name:{Name} "+ Card.ToString;
        }
    }
}
