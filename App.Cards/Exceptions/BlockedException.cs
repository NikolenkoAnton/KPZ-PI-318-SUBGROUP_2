using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Cards.Exceptions
{
    public class BlockedException : Exception
    {
        public int CardId { get; set; }
        public BlockedException(int cardId)
        {
            CardId = cardId;
        }
    }
}
