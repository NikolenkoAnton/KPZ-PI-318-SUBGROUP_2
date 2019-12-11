using App.Deposits.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Deposits.DataBase
{
    public class DepositsDbContext : DbContext
    {
        public DbSet<Deposit> Deposits { get; set; }

        public DepositsDbContext(DbContextOptions<DepositsDbContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Deposit>()
                .HasKey(d => d.Id);
        }
    }
}
