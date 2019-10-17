using App.Cards.Models;
using App.Cards.Repositories;
using App.Configuration;
using System;

namespace App.Cards
{
    public interface ICardsManager
    {
        Card GetCardById(int id);

        void SetCardLimit(int id, decimal limit);

        void UnsetCardLimit(int id);

        void BlockCard(int id);
    }
    public class CardsManager : ICardsManager, ITransientDependency
    {
        private readonly ICardsRepository cardsRepository;

        public CardsManager(ICardsRepository cardsRepository)
        {
            this.cardsRepository = cardsRepository;
        }

        public void BlockCard(int id)
        {
            var card = cardsRepository.GetCardById(id);

            if (card == null)
            {
                throw new Exception("Card doesn't exist!");
            }

            if (card.IsBlocked)
            {
                throw new Exception("Card blocked!");

            }

            card.IsBlocked = true;
        }

        public Card GetCardById(int id)
        {
            return cardsRepository.GetCardById(id);
        }

        public void SetCardLimit(int id, decimal limit)
        {
            var card = cardsRepository.GetCardById(id);

            if (card == null)
            {
                throw new Exception("Card doesn't exist!");
            }

            if (card.IsBlocked)
            {
                throw new Exception("Card blocked!");

            }
            card.Limit = limit;

        }

        public void UnsetCardLimit(int id)
        {
            var card = cardsRepository.GetCardById(id);

            if (card == null)
            {
                throw new Exception("Card doesn't exist!");
            }

            if (card.IsBlocked)
            {
                throw new Exception("Card blocked!");
            }

            card.Limit = 0;

        }
    }
}
