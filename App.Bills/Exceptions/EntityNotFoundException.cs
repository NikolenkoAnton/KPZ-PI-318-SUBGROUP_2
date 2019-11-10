using System;
using System.Collections.Generic;
using System.Text;

namespace App.Accounts.Exceptions
{
    class EntityNotFoundException : Exception
    {
        public Type EntityType { get; private set; }
        public EntityNotFoundException(Type entityType)
        {
            EntityType = entityType;
        }
    }
}
