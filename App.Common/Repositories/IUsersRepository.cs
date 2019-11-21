using App.Models.Users;
using System.Collections.Generic;

namespace App.Repositories
{
    public interface IUsersRepository
    {
        List<User> GetAll();

        User GetById(int id);

        void Create(User user);

        void Update(User user);

        void Delete(User user);
    }
}
