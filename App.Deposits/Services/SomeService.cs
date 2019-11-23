using App.Configuration;

namespace App.Deposits.Services
{
    public interface ISomeService
    {
        void DoSmth();
    }

    public class SomeService : ISomeService, ITransientDependency
    {
        public void DoSmth()
        {
        }
    }
}
