using System.Collections.Generic;

namespace App.Repositories
{
    /// <summary>
    /// This is example repository, which provide single method to access values
    /// </summary>
    public interface IValuesRepository
    {
        IEnumerable<string> GetValues();
    }
}
