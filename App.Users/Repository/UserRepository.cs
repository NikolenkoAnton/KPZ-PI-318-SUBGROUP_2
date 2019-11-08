using App.Configuration;
using App.Users.Domain;
using App.Users.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Users.Repositories
{

    public interface IUserRepository
    {
        List<User> GetAll();

        User GetByLogin(string login);

        void Create(User user);

        void Update(User user);

        void Delete(int Id);
    }

    public class UserRepository : IUserRepository, ISingletoneDependency
    {
        private readonly List<User> users;

        public UserRepository()
        {
            users = InitUsers();
        }

        private static List<User> InitUsers()
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, IsAvailable = true, Login = "Chuck01", Name = "Chuck Norris", Password = "qwerty" });
            users.Add(new User { Id = 2, IsAvailable = false, Login = "john_qw", Name = "John Smith", Password = "password" });
            users.Add(new User { Id = 3, IsAvailable = true, Login = "GeRaLT", Name = "Thomas Nelson", Password = "12345" });
            return users;
        }

        public void Create(User user)
        {
            if (users.Contains(user))
            {
                throw new RepositoryException("Unable to write user by id {0}, user already exist", user.Id);
            }
            else
            {
                users.Add(user);
            }
        }

        public void Delete(int Id)
        {
            User instance = users.Find(user => user.Id.Equals(Id));
            if (instance != null)
            {
                users.Remove(instance);
            } else
            {
                throw new RepositoryException("Unable to delete user by id {0}, user does not exist", Id);
            }
        }

        public List<User> GetAll() => users;

        public User GetByLogin(string login) => users.Find(user => user.Login.Equals(login));

        public void Update(User user)
        {
            int userIndex = users.FindIndex(instance => instance.Id.Equals(user.Id));

            if (userIndex < 0)
            {
                throw new RepositoryException("Unable to update user by id {0}, user does not exist", user.Id);
            }
            else
            {
                users[userIndex] = user;
            }
        }
    }
}
