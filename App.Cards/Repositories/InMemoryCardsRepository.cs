﻿using App.Cards.Models;
using App.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Cards.Database;

namespace App.Cards.Repositories
{
    public interface ICardsRepository
    {
        IEnumerable<Card> GetAllCards();

        Card GetCardById(int id);

    }
    public class InMemoryCardsRepository : ICardsRepository, ITransientDependency
    {
        private AppCardsDbContext context;

        public InMemoryCardsRepository(AppCardsDbContext context)
        {
            this.context = context;
        }

        public Card GetCardById(int id) => context.Cards.Where(x => x.Id == id).FirstOrDefault();

        public IEnumerable<Card> GetAllCards() => context.Cards;

    }
}
