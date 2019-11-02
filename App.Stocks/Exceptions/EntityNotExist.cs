using System;
using System.Collections.Generic;
using System.Text;

namespace App.Stocks.Exceptions {
    public class EntityNotExistException : Exception {
        public Type EntityType { get; private set; }
        public int EntityId { get; set; }
        public EntityNotExistException (Type EntityType, int EntityId) {
            this.EntityType = EntityType;
            this.EntityId = EntityId;
        }
    }
}