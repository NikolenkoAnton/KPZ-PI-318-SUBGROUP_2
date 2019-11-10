using System;
using System.Collections.Generic;
using System.Text;

namespace App.Accounts.Exceptions
{
    class BillAlreadyUnlockedException : Exception
    {
        public int BillId { get; set; }
        public BillAlreadyUnlockedException(int billId)
        {
            BillId = billId;
        }
    }
}
