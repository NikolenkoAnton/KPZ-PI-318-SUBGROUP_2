using System.Collections.Generic;
using App.Configuration;
using App.UserSupport.Repositories;
using App.UserSupport.Models;
using Microsoft.Extensions.Logging;
using App.UserSupport.Exceptions;
using System.Linq;

namespace App.UserSupport
{ 
    public interface IUserSupportManager
    {
        void SetHandlingStatusCompleted(int id);
        IEnumerable<Handling> GetListActiveHandlings();
        IEnumerable<Message> GetHandling10LastMessages(int id);
    }
    public class UserSupportManager : IUserSupportManager, ITransientDependency
    {
        readonly IHandlingsRepository repository;
        private readonly ILogger<UserSupportManager> logger;

        public UserSupportManager(IHandlingsRepository repository
            ,ILogger<UserSupportManager> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

       public void SetHandlingStatusCompleted(int id)
        {
            SetupHandlingStatusCompleted(id);
        }

        public IEnumerable<Message> GetHandling10LastMessages(int id)
        {
            return Handling10LastMessages(id);
        }

        public IEnumerable<Handling> GetListActiveHandlings()
        {
            return repository.GetHandlings();
        }

        private void SetupHandlingStatusCompleted(int id)
        {
            var get = repository.Get(id);
            logger.LogDebug("Method:SetupHandlingStatusCompleted");
            if (get == null)
                throw new EntityNotFoundException(typeof(Handling));
            logger.LogDebug("Method:SetupHandlingStatusCompleted");
            if (get.status == true)
                throw new HandlingAlreadyCompeletedException(id);
            get.status = true;
        }
        private IEnumerable<Message> Handling10LastMessages(int id)
        {
            logger.LogDebug("Method:Handling10LastMessages");
            if (repository.Get(id) == null)
                throw new EntityNotFoundException(typeof(Handling));
            IEnumerable<Message> somelist = repository.Get(id).context.ToArray();
            return somelist.Reverse();
        }
    }
}
