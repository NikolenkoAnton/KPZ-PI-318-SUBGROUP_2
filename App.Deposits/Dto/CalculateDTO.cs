﻿using System;

namespace App.Deposits.Models
{
    public class CalculateDTO
    {
        public decimal StartSum { get; set; }

        public DateTime FinishDate { get; set; }

        public int GetDaysAmount() => (FinishDate - DateTime.Now).Days;
    }
}
