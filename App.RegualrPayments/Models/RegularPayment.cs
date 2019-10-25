using System;

namespace App.RegularPayments.Models
{
    public class RegularPayment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Sum { get; set; }
        public DateTime Date { get; set; }
        public bool State { get; set; }
    }
}
