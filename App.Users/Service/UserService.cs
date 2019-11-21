using App.Configuration;
using App.Users.Domain;
using App.Users.Exceptions;
using App.Users.Repositories;
using System.Collections.Generic;

namespace App.Users.Service
{
    public interface IUserService
    {
        List<User> GetAllActive();

        void ChangePassword(string login, string oldPassword, string newPassword, string confirmPassword);

        void BlockUser(string login);

        void UnblockUser(string login);
    }

    public class UserService : IUserService, ITransientDependency
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void BlockUser(string login)
        {
            User user = userRepository.GetByLogin(login);
            if (user.IsAvailable)
            {
                user.IsAvailable = false;
            } else
            {
                throw new ServiceException("Unable to block user by id {0}, user already blocked", user.Id);
            }
            userRepository.Update(user);
        }

        public void ChangePassword(string login, string oldPassword, string newPassword, string confirmPassword)
        {
            User user = userRepository.GetByLogin(login);
            if (!user.Password.Equals(oldPassword))
            {
                throw new ServiceException("Unable to change password for user by id {0}, the old password is incorect", user.Id);
            } else if (!newPassword.Equals(confirmPassword))
            {
                throw new ServiceException("Unable to change password for user by id {0}, passwords do not match", user.Id);
            } else
            {
                user.Password = newPassword;
            }
            userRepository.Update(user);
        }

        public List<User> GetAllActive()
        {
            List<User> users = userRepository.GetAll();
            List<User> availableUsers = new List<User>();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].IsAvailable)
                {
                    availableUsers.Add(users[i]);
                }
            }
            return availableUsers;
        }

        public void UnblockUser(string login)
        {
            User user = userRepository.GetByLogin(login);
            if (!user.IsAvailable)
            {
                user.IsAvailable = true;
            }
            else
            {
                throw new ServiceException("Unable to unblock user by id {0}, user already unblocked", user.Id);
            }
            userRepository.Update(user);
        }
    }
}
