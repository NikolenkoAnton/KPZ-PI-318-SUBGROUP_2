using App.Configuration;
using App.Models.Users;
using App.Repositories;
using App.Users.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Users.Repository
{
    public class EfUserRepository : IUsersRepository, IDisposable, ISingletoneDependency
    {
        private readonly UsersDbContext dbContext;

        public EfUserRepository(UsersDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<User> GetAll()
        {
            return dbContext.SimpleValues.ToList();
        }

        public User GetById(int id)
        {
            return dbContext.SimpleValues.Where(sv => sv.Id == id).FirstOrDefault();
        }

        public void Create(User user)
        {
            dbContext.SimpleValues.Add(user);
        }

        public void Update(User user)
        {
            dbContext.SimpleValues.Update(user);
        }

        public void Delete(User user)
        {
            dbContext.SimpleValues.Remove(user);
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }
    }
}
