using App.Accounts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Accounts
{
    public class AccountsDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>()
                .HasKey(account => account.Id);
        }
    }
}
