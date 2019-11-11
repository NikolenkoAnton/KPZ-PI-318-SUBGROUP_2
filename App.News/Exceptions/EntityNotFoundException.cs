using System;

namespace App.News.Exceptions
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
