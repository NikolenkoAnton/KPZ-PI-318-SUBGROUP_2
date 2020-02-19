using System.Collections.Generic;
using App.Configuration;
using App.Repositories;

namespace App.Example.Repositories
{
    /// <summary>
    /// Fake repository implementation, which stores value in memory
    /// </summary>
    public class InMemoryValuesRepository : IValuesRepository, ITransientDependency
    {
        public IEnumerable<string> GetValues()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
