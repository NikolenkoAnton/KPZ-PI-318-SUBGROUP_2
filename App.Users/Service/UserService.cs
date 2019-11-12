using App.Configuration;
using App.Users.Domain;
using App.Users.Exceptions;
using App.Users.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace App.Users.Service
{
    public interface IUserService
    {
        List<User> GetAllActive();

        void ChangePassword(int userId, string oldPassword, string newPassword, string confirmPassword);

        void BlockUser(int userId);

        void UnblockUser(int userId);
    }

    public class UserService : IUserService, ITransientDependency
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<UserService> logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public List<User> GetAllActive()
        {
            logger.LogDebug($"Method:GetAllActive");
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

        public void ChangePassword(int userId, string oldPassword, string newPassword, string confirmPassword)
        {
            logger.LogDebug($"Method:ChangePassword");
            User user = userRepository.GetById(userId);
            if (!user.Password.Equals(oldPassword))
            {
                throw new PasswordVerificationException("Unable to change password for user by id {0}, the old password is incorect", user.Id);
            } else if (!newPassword.Equals(confirmPassword))
            {
                throw new PasswordVerificationException("Unable to change password for user by id {0}, passwords do not match", user.Id);
            } else
            {
                user.Password = newPassword;
            }
            userRepository.Update(user);
        }

        public void BlockUser(int userId)
        {
            logger.LogDebug($"Method:BlockUser");
            User user = userRepository.GetById(userId);
            if (user.IsAvailable)
            {
                user.IsAvailable = false;
            } else
            {
                throw new UserAvailabilityException("Unable to block user by id {0}, user already blocked", user.Id, user.IsAvailable);
            }
            userRepository.Update(user);
        }

        public void UnblockUser(int userId)
        {
            logger.LogDebug($"Method:UnblockUser");
            User user = userRepository.GetById(userId);
            if (!user.IsAvailable)
            {
                user.IsAvailable = true;
            }
            else
            {
                throw new UserAvailabilityException("Unable to unblock user by id {0}, user already unblocked", user.Id, user.IsAvailable);
            }
            userRepository.Update(user);
        }
    }
}
