using App.Configuration;

namespace App.Web
{
    [ModuleUsing(typeof(Example.ExampleModule))]
    [ModuleUsing(typeof(Loans.LoansModule))]
    public class Modules
    {
    }
}
