﻿using App.Configuration;

namespace App.Web
{
    /// <summary>
    /// IMPORTANT ! In order to use classes and endpoints, defined in your own module, it should be referenced here as it shown
    /// </summary>
    [ModuleUsing(typeof(Example.ExampleModule))] // < ---- Example of module registration
    [ModuleUsing(typeof(UserSupport.UserSupportModule))]
    [ModuleUsing(typeof(Goods.GoodsModule))]
    [ModuleUsing(typeof(Stocks.StocksModule))]
    [ModuleUsing(typeof(Loans.LoansModule))]
    public class Modules
    {
        
    }
}
