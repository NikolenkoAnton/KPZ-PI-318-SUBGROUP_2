using App.Configuration;

namespace App.Web
{
    /// IMPORTANT ! In order to use classes and endpoints, defined in your own module, it should be referenced here as it shown
    /// </summary>
    [ModuleUsing(typeof(Example.ExampleModule))] // < ---- Example of module registration
    [ModuleUsing(typeof(Example.StocksModule))]
    public class Modules
    {
    }
}
