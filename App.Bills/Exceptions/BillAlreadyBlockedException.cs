using System;
using System.Collections.Generic;
using System.Text;

namespace App.Accounts.Exceptions
{
    class BillAlreadyBlockedException : Exception
    {
        public int BillId { get; set; }
        public BillAlreadyBlockedException(int billId)
        {
            BillId = billId;
        }
    }
}
