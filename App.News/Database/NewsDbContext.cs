using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using App.News.Models;
namespace App.News.Database
{
    public class NewsDbContext : DbContext
    {

        public DbSet<NewsDTO> News { get; set; }
        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options) { }

        // method for configuring object-relational mapping
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<NewsDTO>()
                .HasKey(sv => sv.id);
        }

    }
}
