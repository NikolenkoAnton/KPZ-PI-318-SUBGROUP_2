using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using App.Customers.Models;
namespace App.Customers
{
    public class CustomersDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CustomersDBContext(DbContextOptions<CustomersDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}