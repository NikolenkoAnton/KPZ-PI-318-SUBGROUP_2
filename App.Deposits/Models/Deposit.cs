using System;
using System.Collections.Generic;
using System.Text;

namespace App.Deposits.Models
{
    public class Deposit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal InterestRate { get; set; }
    }
}
