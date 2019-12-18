using App.Configuration;
using App.Models.Users;
using App.Repositories;
using App.Users.Database;
using App.Users.Exception;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Users.Repository
{
    public class EfUserRepository : IUsersRepository, IDisposable, ITransientDependency
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
            var instance = dbContext.SimpleValues.Where(sv => sv.Id == id).FirstOrDefault();
            if (instance == null)
            {
                throw new EntityNotFoundException("Unable to find user by id {0}, user does not exist", id);
            }
            else
            {
                return instance;
            }
        }

        public void Create(User user)
        {
            if (dbContext.SimpleValues.Contains(user))
            {
                throw new EntityUniqueViolatedException("Unable to write user by id {0}, user already exist", user.Id);
            }
            else
            {
                dbContext.SimpleValues.Add(user);
            }
            dbContext.SaveChanges();
        }

        public void Update(User user)
        {
            if (dbContext.SimpleValues.Contains(user))
            {
                dbContext.SimpleValues.Update(user);
            }
            else
            {
                throw new EntityNotFoundException("Unable to update user by id {0}, user does not exist", user.Id);
            }
            dbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            if (dbContext.SimpleValues.Contains(user))
            {
                dbContext.SimpleValues.Remove(user);
            }
            else
            {
                throw new EntityNotFoundException("Unable to update user by id {0}, user does not exist", user.Id);
            }
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }
    }
}
