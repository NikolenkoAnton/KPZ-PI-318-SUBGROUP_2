using System;
using System.Collections.Generic;
using System.Text;

namespace App.Customers.Models
{
    public class Customer
    {

        public List<Prop> Props { get; set; }
        public string Name { get; set; }

        public Customer(string name)
        {
            this.Name = name;
            this.Props = new List<Prop>();
        }
    }
}
