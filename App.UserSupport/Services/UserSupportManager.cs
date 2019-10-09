using System.Collections.Generic;
using App.Configuration;
using App.UserSupport.Repositories;

namespace App.UserSupport
{
    public interface IUserSupportManager
    {
        void Set_Handling_Status_Completed(int id);
        IEnumerable<string> GetActiveValues();
        string Get_Handling_10_last_messages(int id);
    }
    public class UserSupportManager : IUserSupportManager, ITransientDependency
    {
        readonly IUsersRepository _repository;
        public UserSupportManager(IUsersRepository repository)
        {
            _repository = repository;
        }
       public void Set_Handling_Status_Completed(int id)
        {
            _repository.Get(id).Set_Handling_Status_Completed();
        }
        public IEnumerable<string> Get_Handling_10_last_messages(int id)
        {
            return new string[] { _repository.Get(id).Get_Handling_10_last_messages() };
        }
        public IEnumerable<string> GetActiveValues()
        {
            return _repository.GetActiveValues();
        }
    }
}
