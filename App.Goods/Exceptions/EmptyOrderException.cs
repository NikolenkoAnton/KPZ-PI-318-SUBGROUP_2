using System;

namespace App.Goods.Exceptions
{
    public class EmptyOrderException : Exception
    {
        public int OrderId { get; private set; }

        public EmptyOrderException(int orderId)
        {
            OrderId = orderId;
        }
    }
}
