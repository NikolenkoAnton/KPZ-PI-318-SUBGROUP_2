using App.Cards.Repositories;
using App.Configuration;
using System;

namespace App.Cards
{
    public interface ICardsManager
    {

    }
    public class CardsManager : ICardsManager, ITransientDependency
    {
        private readonly ICardsRepository cardsRepository;

        public CardsManager(ICardsRepository cardsRepository)
        {
            this.cardsRepository = cardsRepository;
        }
    }
}
