using System;
using System.Collections.Generic;
using System.Text;

namespace App.Cards.Models
{
    public class Card
    {
        public int Id { get; set; }

        public decimal Limit { get; set; }

        public bool IsBlocked { get; set; }
    }
}
