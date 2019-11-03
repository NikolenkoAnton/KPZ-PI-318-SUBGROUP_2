using App.Cards.Exceptions;
using App.Cards.Models;
using App.Cards.Repositories;
using App.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CardsManager> logger;
        public CardsManager(ICardsRepository cardsRepository, ILogger<CardsManager> logger)
        {
            this.cardsRepository = cardsRepository;
            this.logger = logger;
        }

        public void BlockCard(int id)
        {
            logger.LogDebug($"Method:BlockCard, classType:{this.GetType()}");
            var card = cardsRepository.GetCardById(id);

            if (card == null)
            {
                throw new EntityNotFoundException(card.GetType());
            }

            if (card.IsBlocked)
            {
                throw new BlockedException(card.Id);
            }

            card.IsBlocked = true;
        }

        public Card GetCardById(int id)
        {
            logger.LogDebug($"Method:GetCardById, classType:{this.GetType()}");

            return cardsRepository.GetCardById(id);
        }

        public void SetCardLimit(int id, decimal limit)
        {
            logger.LogDebug($"Method:SetCardLimit, classType:{this.GetType()}");


            if (limit < 0)
            {
                throw new LimitException("SetLimit", "Limit can't be less than 0!");
            }
            var card = cardsRepository.GetCardById(id);

            if (card == null)
            {
                throw new EntityNotFoundException(card.GetType());
            }

            if (card.IsBlocked)
            {
                throw new BlockedException(card.Id);
            }
            card.Limit = limit;

        }

        public void UnsetCardLimit(int id)
        {
            logger.LogDebug($"Method:UnsetCardLimit, classType:{this.GetType()}");

            var card = cardsRepository.GetCardById(id);

            if (card.Limit == 0)
            {
                throw new LimitException("UnsetLimit", "Card hasn't limit!");
            }
            if (card == null)
            {
                throw new EntityNotFoundException(card.GetType());
            }

            if (card.IsBlocked)
            {
                throw new BlockedException(card.Id);
            }
            card.Limit = 0;

        }
    }
}
