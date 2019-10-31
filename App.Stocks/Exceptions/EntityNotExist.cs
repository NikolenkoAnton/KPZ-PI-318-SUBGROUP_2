using System;
using System.Collections.Generic;
using System.Text;

namespace App.Stocks.Exceptions
{
    public class EntityNotExist : Exception
    {
        public Type EntityType { get; private set; }
        public EntityNotExist(Type EntityType,string message): base(message)
        {
            this.EntityType = EntityType;
        }
    }
}
