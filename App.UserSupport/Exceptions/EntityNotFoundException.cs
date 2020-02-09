using System;
using System.Collections.Generic;
using System.Text;

namespace App.UserSupport.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public Type EntityType { get; private set; }
        public EntityNotFoundException(Type entityType)
        {
            EntityType = entityType;
        }
    }
}
