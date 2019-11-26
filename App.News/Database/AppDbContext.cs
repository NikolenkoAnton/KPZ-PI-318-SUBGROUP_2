using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using App.News.Interfaces;
using App.News.Models;
namespace App.News.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<NewsDto> News { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // method for configuring object-relational mapping
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<NewsDto>()
                .HasKey(sv => sv.Id);
        }

    }
}
