using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using System.Threading.Tasks;

namespace App.UserSupport.Filters
{
    public class UserSupportExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
