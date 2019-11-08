﻿using App.Configuration;

namespace App.Web
{
    /// <summary>
    /// IMPORTANT ! In order to use classes and endpoints, defined in your own module, it should be referenced here as it shown
    /// </summary>
    [ModuleUsing(typeof(Example.ExampleModule))] // < ---- Example of module registration
    [ModuleUsing(typeof(Users.UsersModule))]

    [ModuleUsing(typeof(News.NewsModule))]
    [ModuleUsing(typeof(UserSupport.UserSupportModule))]
    [ModuleUsing(typeof(Goods.GoodsModule))]
    [ModuleUsing(typeof(Stocks.StocksModule))]
    [ModuleUsing(typeof(Loans.LoansModule))]
    [ModuleUsing(typeof(Deposits.DepositsModule))]
    [ModuleUsing(typeof(Bills.BillsModule))]

    public class Modules
    {

    }
}
