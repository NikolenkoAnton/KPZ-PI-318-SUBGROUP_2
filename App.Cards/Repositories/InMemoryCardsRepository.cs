using App.Cards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Cards.Repositories
{
    public interface ICardsRepository
    {
        IEnumerable<Card> GetAllCards();

        Card GetCardById(int id);
    }
    public class InMemoryCardsRepository
    {
        private static readonly List<Card> cards = Init();

        public Card GetCardById(int id) => cards.Where(x => x.Id == id).FirstOrDefault();

        public IEnumerable<Card> GetAllCards() => cards;
      

        private static List<Card> Init()
        {
            List<Card> cards = new List<Card>();

            for (int i = 0; i < 8; i++)
            {
                cards.Add(
                    new Card
                    {
                        Id = i,
                        Limit = 0,
                        IsBlocked = false,
                    }
                );
            }
            return cards;
        }
    }
}
