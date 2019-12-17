using System.Collections.Generic;
using App.Configuration;
using App.UserSupport.Models;
using System.Linq;

namespace App.UserSupport.Repositories
{
    public interface IHandlingsRepository
    {
        IQueryable<Handling> GetHandlings();
        Handling Get(int id);
    }
}
