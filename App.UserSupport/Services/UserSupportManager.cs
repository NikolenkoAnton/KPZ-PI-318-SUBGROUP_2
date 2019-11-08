using System.Collections.Generic;
using App.Configuration;
using App.UserSupport.Repositories;
using App.UserSupport.Models;
using Microsoft.Extensions.Logging;
using App.UserSupport.Exceptions;

namespace App.UserSupport
{
    public interface IUserSupportManager
    {
        void SetHandlingStatusCompleted(int id);
        IEnumerable<string> GetListActiveHandlings();
        IEnumerable<string> GetHandling10LastMessages(int id);
    }
    public class UserSupportManager : IUserSupportManager, ITransientDependency
    {
        readonly IHandlingsRepository repository;
        private readonly ILogger<UserSupportManager> logger;

        public UserSupportManager(IHandlingsRepository repository)
        {
            this.repository = repository;
        }

       public void SetHandlingStatusCompleted(int id)
        {
            SetupHandlingStatusCompleted(id);
        }

        public IEnumerable<string> GetHandling10LastMessages(int id)
        {
            return new string[] { Handling10LastMessages(id) };
        }

        public IEnumerable<string> GetListActiveHandlings()
        {
            return repository.GetStringListActiveHandlings();
        }

        private void SetupHandlingStatusCompleted(int id)
        {
            logger.LogDebug($"Method:SetupHandlingStatusCompleted");
            if (repository.Get(id) == null)
                throw new EntityNotFoundException(typeof(Handling));
            logger.LogDebug($"Method:SetupHandlingStatusCompleted");
            if (repository.Get(id).status == true)
                throw new HandlingAlreadyCompeletedException(id);
            repository.Get(id).status = true;
        }
        private string Handling10LastMessages(int id)
        {
            logger.LogDebug($"Method:Handling10LastMessages");
            if (repository.Get(id) == null)
                throw new EntityNotFoundException(typeof(Handling));
            string temp = "";
            List<Message> somelist = repository.Get(id).context;
            somelist.Reverse();
            int i = repository.Get(id).context.Count - 1;
            int j = 0;
            while (i >= 0)
            {
                if (j < 10)
                    temp += somelist[i].mess;
                i--;
                j++;
            }
            return temp;
        }
    }
}
