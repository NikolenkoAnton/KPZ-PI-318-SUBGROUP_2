using System;
using System.Collections.Generic;
using System.Text;
using App.UserSupport.Models;
using App.Configuration;
using System.Linq;

namespace App.UserSupport.Repositories
{
    public class EFRepositoryUserSupport : IHandlingsRepository, ITransientDependency
    {
        private readonly UserSupportDBContext _userSupportDBContext;
        public EFRepositoryUserSupport(UserSupportDBContext userSupportDB)
        {
            _userSupportDBContext = userSupportDB;
        }
        public IQueryable<Handling> GetHandlings() => _userSupportDBContext.Handlings;
        public Handling Get(int id) => _userSupportDBContext.Handlings.Where(f => f.Id == id).FirstOrDefault();
    }
}
