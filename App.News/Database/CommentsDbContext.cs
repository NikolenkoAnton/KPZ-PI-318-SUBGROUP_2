using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using App.News.Models;
namespace App.News.Database
{
    public class CommentsDbContext : DbContext
    {

        public DbSet<Comment> News { get; set; }
        public CommentsDbContext(DbContextOptions<CommentsDbContext> options) : base(options) { }

        // method for configuring object-relational mapping
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Comment>()
                .HasKey(sv => sv.Id);
        }

    }
}
