using Microsoft.EntityFrameworkCore;
using App.UserSupport.Models;

namespace App.UserSupport
{
    public class UserSupportDBContext : DbContext
    {

        public DbSet<Handling> Handlings { get; set; }
        public DbSet<Message> Messages { get; set; }

        public UserSupportDBContext(DbContextOptions<UserSupportDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder) { }
    }
}
