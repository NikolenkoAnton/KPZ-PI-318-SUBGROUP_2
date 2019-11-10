using System;
using System.Collections.Generic;
using System.Text;

namespace App.Deposits.Exceptions
{
    public class EntityNotExistException : Exception
    {
        public Type EntityType { get; private set; }

        public int EntityId { get; private set; }

        public EntityNotExistException(Type entityType, int entityId)
        {
            EntityId = entityId;
            EntityType = entityType;
        }
    }
}
