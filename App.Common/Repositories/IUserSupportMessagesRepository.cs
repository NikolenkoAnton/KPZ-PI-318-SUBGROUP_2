using System.Collections.Generic;

namespace App.Repositories
{
    public interface IUserSupportMessagesRepository
    {

        IEnumerable<string> GetValues();

    }
}
