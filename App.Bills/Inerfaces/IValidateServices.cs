using App.Accounts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Accounts.Inerfaces
{
    public interface IValidateServices
    {
        void ValidateBill(Account bill);
    }
}
