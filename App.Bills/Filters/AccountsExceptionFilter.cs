using App.Accounts.Exceptions;
using App.Accounts.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Accounts.Filters
{
    class AccountsExceptionFilter : IAsyncExceptionFilter
    {
        readonly string _context;
        readonly ILogger<AccountsExceptionFilter> logger;
        readonly ILocalizationManager _localizationManager;

        public AccountsExceptionFilter(ILogger<AccountsExceptionFilter> logger, string context, ILocalizationManager localizationManager)
        {
            this.logger = logger;
            _context = context;
            _localizationManager = localizationManager;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            logger.LogError(context.Exception, $"Error occurred in context of {_context}");

            switch (context.Exception)
            {
                case EntityNotFoundException entityNotFound:
                    {

                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        var errorMessage = _localizationManager.GetResource("ResourceNotFound");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                case BillAlreadyBlockedException blockedException:
                    {

                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var errorMessage = _localizationManager.GetResource("BillIsBlocked");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                case BillAlreadyUnlockedException unlockedException:
                    {

                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var errorMessage = _localizationManager.GetResource("BillIsUnblocked");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                default:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var errorMessage = _localizationManager.GetResource("UnhandledException");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
            }
            context.ExceptionHandled = true; 
        }
    }
}
