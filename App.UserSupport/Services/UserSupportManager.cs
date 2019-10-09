using System.Collections.Generic;
using App.Configuration;
using App.UserSupport.Repositories;

namespace App.UserSupport
{
    public interface IUserSupportManager
    {
        void SetHandlingStatusCompleted(int id);
        IEnumerable<string> GetActiveValues();
        IEnumerable<string> GetHandling10LastMessages(int id);
    }
    public class UserSupportManager : IUserSupportManager, ITransientDependency
    {
        readonly IUsersRepository repository;

        public UserSupportManager(IUsersRepository repository)
        {
            this.repository = repository;
        }

       public void SetHandlingStatusCompleted(int id)
        {
            repository.Get(id).SetHandlingStatusCompleted();
        }

        public IEnumerable<string> GetHandling10LastMessages(int id)
        {
            return new string[] { repository.Get(id).GetHandling10LastMessages() };
        }

        public IEnumerable<string> GetActiveValues()
        {
            return repository.GetActiveValues();
        }
    }
}
