using App.Configuration;

namespace App.Web
{
    
    [ModuleUsing(typeof(Example.ExampleModule))]
    [ModuleUsing(typeof(Example.StocksModule))]
    public class Modules
    {
    }
}
