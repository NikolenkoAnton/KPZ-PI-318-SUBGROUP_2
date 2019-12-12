using System;
using System.Collections.Generic;
using System.Text;
using App.Accounts.Inerfaces;
using App.Accounts.Models;

namespace App.Accounts
{
    public class ValidateServices : IValidateServices
    {
        public void ValidateBill(Account bill)
        {
            if (bill.Name == null || bill.Name == "" || bill.Surname == null || bill.Surname == "")
                throw new Exception("Bill owner doesn't exist!");
        }
    }
}
