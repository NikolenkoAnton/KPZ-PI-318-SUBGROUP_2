using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using App.Cards.Models;

namespace App.Cards.Database
{
    public class CardsDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public CardsDbContext(DbContextOptions<CardsDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Card>()
                .HasKey(sv => sv.Id);
        }

    }
}
