namespace App.UserSupport
{ 
  //This classes just for UserSupportModule.cs and manual connecting to Modules.cs
    public interface IAnotherService
    {
        void DoAnything();
    }

    public class AnotherService : IAnotherService
    {
        public void DoAnything()
        {
        }
    }
}
