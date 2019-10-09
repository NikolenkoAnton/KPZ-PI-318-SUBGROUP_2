using App.Cards.Models;
using App.Cards.Repositories;
using App.Configuration;
using System;

namespace App.Cards
{
    public interface ICardsManager
    {
        Card GetCardById(int id);

        string SetCardLimit(int id, decimal limit);

        string UnsetCardLimit(int id);

        string BlockCard(int id);
    }
    public class CardsManager : ICardsManager, ITransientDependency
    {
        private readonly ICardsRepository cardsRepository;

        public CardsManager(ICardsRepository cardsRepository)
        {
            this.cardsRepository = cardsRepository;
        }

        public string BlockCard(int id)
        {
            var card = cardsRepository.GetCardById(id);

            if(card == null)
            {
                return "Card doesn't exist!";
            }

            if(card.IsBlocked)
            {
                return "Card blocked!";
            }

            card.IsBlocked = true;

            return "Successfull";
        }

        public Card GetCardById(int id)
        {
            return cardsRepository.GetCardById(id);
        }

        public string SetCardLimit(int id, decimal limit)
        {
            var card = cardsRepository.GetCardById(id);

            if (card == null)
            {
                return "Card doesn't exist!";
            }

            if (card.IsBlocked)
            {
                return "Card blocked!";
            }
            card.Limit = limit;

            return "Successfull";

        }

        public string UnsetCardLimit(int id)
        {
            var card = cardsRepository.GetCardById(id);

            if (card == null)
            {
                return "Card doesn't exist!";
            }

            if (card.IsBlocked)
            {
                return "Card blocked!";
            }

            card.Limit = 0;

            return "Successfull";

        }
    }
}
