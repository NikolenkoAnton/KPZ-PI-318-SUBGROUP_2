using System.Collections.Generic;
using App.Configuration;
using App.Repositories;


namespace App.UserSupport
{
         /// <summary>
         /// Example manager class. Which should process business logic, and call required repository
         /// </summary>
    public interface IUserSupportManager
    {
        IEnumerable<string> GetValues();
    }

    public class UserSupportManager : IUserSupportManager, ITransientDependency
    {
        // propoerty should be readonly, so it could not be changed after initialization
        readonly IUserSupportMessagesRepository _repository;
        // resolving repository through constructor dependency
        public UserSupportManager(IUserSupportMessagesRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<string> GetValues()
        {
            return _repository.GetValues();
        }
    }
}
