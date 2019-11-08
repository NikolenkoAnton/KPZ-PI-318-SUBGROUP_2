using System;
using System.Collections.Generic;
using System.Text;

namespace App.Bills.Exceptions
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
