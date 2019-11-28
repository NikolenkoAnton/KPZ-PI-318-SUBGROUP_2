using Microsoft.EntityFrameworkCore;
using App.Configuration;
using App.Stocks.Interfaces;
using App.Stocks.Models;

namespace App.Stocks
{
    public class StocksDBContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public StocksDBContext(DbContextOptions<StocksDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}