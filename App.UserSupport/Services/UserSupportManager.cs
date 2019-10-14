using System.Collections.Generic;
using App.Configuration;
using App.UserSupport.Repositories;

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



        public void SetupHandlingStatusCompleted(int id) => repository.Get(id).status = true;

        private string Handling10LastMessages(int id)
        {
            string temp = "";
            List<string> somelist = repository.Get(id).context;
            somelist.Reverse();
            int i = repository.Get(id).context.Count - 1;
            int j = 0;
            while (i >= 0)
            {
                if (j < 10)
                    temp += somelist.ToArray()[i];
                i--;
                j++;
            }
            return temp;
        }
    }
}
