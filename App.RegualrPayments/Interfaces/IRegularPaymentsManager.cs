using System;
using System.Collections.Generic;
using System.Text;
using App.RegularPayments.Models;

namespace App.RegularPayments.Interfaces
{
    public interface IRegularPaymentsManager
    {
        void AddPayment(RegularPayment payment);
        RegularPayment GetPayment(int id);
        RegularPayment GetNext();
    }
}
