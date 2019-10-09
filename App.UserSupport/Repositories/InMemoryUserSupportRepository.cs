using System.Collections.Generic;
using App.Configuration;
using App.Repositories;
using App.UserSupport.Models;

namespace App.UserSupport.Repositories
{
    /// <summary>
    /// Fake repository implementation, which stores value in memory
    /// </summary>
    public interface IUsersRepository
    {
        IEnumerable<string> GetActiveValues();
        Handling Get(int id);
    }
    public class InMemoryUsersRepository : IUsersRepository, ITransientDependency
    {
        Handling[] handlings = new Handling[5];
        string[] handling = new string[5];
        public InMemoryUsersRepository()
        {
            handlings[0] = new Handling(new Client("Nikita"), "Some times i have troubles", 12);
            handlings[1] = new Handling(new Client("Alina"), "Some times i make troubles", 3);
            handlings[2] = new Handling(new Client("Masha"), "Every times i have troubles", 4);
            handlings[3] = new Handling(new Client("Lana"), "Some times i have exeptions", 1);
            handlings[4] = new Handling(new Client("Anton"), "Some times i have troubles", 2);
            handling[0] = handlings[0].ToString();
            handling[1] = handlings[1].ToString();
            handling[2] = handlings[2].ToString();
            handling[3] = handlings[3].ToString();
            handling[4] = handlings[4].ToString();
        }
        public IEnumerable<string> GetActiveValues()
        {
            return handling;
        }
        public Handling Get(int id)
        {
            return handlings[id];
        }
    }
}
