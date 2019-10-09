using System.Collections.Generic;
using App.Configuration;
using App.UserSupport.Repositories;

namespace App.UserSupport
{
    /// <summary>
    /// Example manager class. Which should process business logic, and call required repository
    /// </summary>
    public interface IUserSupportManager
    {
        void Set_Handling_Status_Completed(int id);
        IEnumerable<string> GetActiveValues();
        IEnumerable<string> Get_Handling_10_last_messages(int id);
    }
    public class UserSupportManager : IUserSupportManager, ITransientDependency
    {
        readonly IUsersRepository repository;
        public UserSupportManager(IUsersRepository repository)
        {
            this.repository = repository;
        }
        public void Set_Handling_Status_Completed(int id)
        {
            repository.Get(id).Set_Handling_Status_Completed();
        }
        public IEnumerable<string> Get_Handling_10_last_messages(int id)
        {
            return new string[] { repository.Get(id).Get_Handling_10_last_messages() };
        }
        public IEnumerable<string> GetActiveValues()
        {
            return repository.GetActiveValues();
        }
    }
}
