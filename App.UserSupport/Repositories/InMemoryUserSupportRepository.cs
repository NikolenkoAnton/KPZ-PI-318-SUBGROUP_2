using System.Collections.Generic;
using App.Configuration;
using App.UserSupport.Models;

namespace App.UserSupport.Repositories
{
    public interface IHandlingsRepository
    {
        IEnumerable<string> GetStringListActiveHandlings();
        Handling Get(int id);
    }
    public class InMemoryUsersRepository : IHandlingsRepository, ITransientDependency
    {
        Handling[] handlings = new Handling[5];
        string[] handling = new string[5];

        public InMemoryUsersRepository()
        {
            handlings[0] = new Handling(new Client("Nikita"), "Some times i have troubles", 2);
            handlings[1] = new Handling(new Client("Alina"), "Some times i make troubles", 3);
            handlings[2] = new Handling(new Client("Masha"), "Every times i have troubles", 4);
            handlings[3] = new Handling(new Client("Lana"), "Some times i have exeptions", 1);
            handlings[4] = new Handling(new Client("Anton"), "Some times i have troubles", 2);
            handlings[1].WriteAnswer("What happend?");
            handlings[2].WriteAnswer("Give me pls more information");
        }

        public IEnumerable<string> GetStringListActiveHandlings()
        {
            handling[0] = handlings[0].ToString();
            handling[1] = handlings[1].ToString();
            handling[2] = handlings[2].ToString();
            handling[3] = handlings[3].ToString();
            handling[4] = handlings[4].ToString();
            return handling;
        }

        public Handling Get(int id)
        {
            if (id >= handlings.Length || id < 0)
                return null;
            return handlings[id];
        }
    }
}
