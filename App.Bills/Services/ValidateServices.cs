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
            if (bill.Name == null || bill.Name == "" || bill.Surname == null || bill.Surname == "")
                throw new Exception("Bill owner doesn't exist!");
        }
    }

    public interface IValidateServices
    {
        void ValidateBill(Bill bill);
    }
}
