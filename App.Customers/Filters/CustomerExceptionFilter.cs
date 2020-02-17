using App.Configuration;
using App.Customers.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Customers.Exceptions
{
    public class CustomerExceptionFilter:IAsyncExceptionFilter, ITransientDependency
    {
        readonly ILogger<CustomerExceptionFilter> _logger;
        readonly ILocalizationManager _localizationManager;

        public CustomerExceptionFilter(ILogger<CustomerExceptionFilter> logger, ILocalizationManager localizationManager)
        {
            _localizationManager = localizationManager;
            _logger = logger;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var _context = context.ActionDescriptor.DisplayName;
            _logger.LogError(context.Exception, $"Error occurred in context of{_context}");
            switch (context.Exception)
            {
                case EntityNotFoundException entityNotFound:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        var errorMessage = _localizationManager.GetResource("EntityNotFound");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                case EntityUniqueCardExceptions entityUniqueCardExceptions:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var errorMessage = _localizationManager.GetResource("EntityUniqueCardExceptions");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                default:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var errorMessage = _localizationManager.GetResource("UnhandeledException");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
            }
            context.ExceptionHandled = true;
        }
    }

}
