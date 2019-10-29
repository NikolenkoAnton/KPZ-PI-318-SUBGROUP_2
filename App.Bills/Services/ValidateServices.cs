using System;
using System.Collections.Generic;
using System.Text;
using App.Bills.Models;

namespace App.Bills
{
    public class ValidateServices : IValidateServices
    {
        public void ValidateBill(Bill bill)
        {
            if (bill.GetIsBlocked())
                throw new Exception("Bill is blocked");
        }
    }

    public interface IValidateServices
    {
        void ValidateBill(Bill bill);
    }
}
