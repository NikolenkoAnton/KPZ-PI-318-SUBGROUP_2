using App.Configuration;
using App.Models.Users;
using App.Users.Exceptions;
using System;
using System.Collections.Generic;
using App.Repositories;
using System.Linq;
using System.Text;

namespace App.Users.Repositories
{
    public class InMemoryUserRepository : IUsersRepository
    {
        private readonly List<User> users;

        public InMemoryUserRepository()
        {
            users = InitUsers();
        }

        private static List<User> InitUsers()
        {
            var users = new List<User>
            {
                new User { Id = 1, IsAvailable = true, Login = "Chuck01", Name = "Chuck Norris", Password = "qwerty" },
                new User { Id = 2, IsAvailable = false, Login = "john_qw", Name = "John Smith", Password = "password" },
                new User { Id = 3, IsAvailable = true, Login = "GeRaLT", Name = "Thomas Nelson", Password = "12345" }
            };
            return users;
        }

        public void Create(User user)
        {
            int userIndex = users.FindIndex(instance => instance.Id.Equals(user.Id));
            if (users.Contains(user) && userIndex > -1)
            {
                throw new EntityUniqueViolatedException("Unable to write user by id {0}, user already exist", user.Id);
            }
            else
            {
                users.Add(user);
            }
        }

        public void Delete(User user)
        {
            int userIndex = users.FindIndex(instance => instance.Id.Equals(user.Id));

            if (userIndex < 0)
            {
                throw new EntityNotFoundException("Unable to delete user by id {0}, user does not exist", user.Id);
            }
            else
            {
                users.Remove(user);
            }
        }

        public List<User> GetAll() => users;

        public User GetById(int id)
        {
            var instance = users.Find(user => user.Id.Equals(id));
            if (instance == null)
            {
                throw new EntityNotFoundException("Unable to find user by id {0}, user does not exist", id);
            } else
            {
                return instance;
            }
        }

        public void Update(User user)
        {
            int userIndex = users.FindIndex(instance => instance.Id.Equals(user.Id));

            if (userIndex < 0)
            {
                throw new EntityNotFoundException("Unable to update user by id {0}, user does not exist", user.Id);
            }
            else
            {
                users[userIndex] = user;
            }
        }
    }
}
