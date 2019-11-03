﻿using System;
using System.Collections.Generic;
using System.Text;
using App.RegularPayments.Models;
namespace App.RegularPayments.Interfaces
{
    public interface IRegularPaymentsRepository
    {
        void Add(RegularPayment payment);
        RegularPayment Get(int id);
        IEnumerable<RegularPayment> GetAll();
    }
}
