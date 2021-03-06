﻿using System;

namespace App.Cards.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public Type EntityType { get; private set; }
        public EntityNotFoundException(Type entityType)
        {
            EntityType = entityType;
        }
        public EntityNotFoundException(string Type) { }
    }
}
