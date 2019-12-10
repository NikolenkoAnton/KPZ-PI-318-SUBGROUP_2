using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using App.Cards.Exceptions;
using App.Cards.Localization;
using App.Configuration;

namespace App.Cards.Filters
{
    /// <summary>
    /// Example of async exception filter.
    /// The purpose of this class -> catch unhandeled exceptions and wrap sensitive data into common form
    /// </summary>
    public class CardsExceptionFilter : IAsyncExceptionFilter, ITransientDependency
    {
        readonly ILogger<CardsExceptionFilter> logger;
        readonly ILocalizationManager _localizationManager;

        public CardsExceptionFilter(ILogger<CardsExceptionFilter> logger, ILocalizationManager localizationManager)
        {
            this.logger = logger;
            _localizationManager = localizationManager;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            logger.LogWarning($"ErrorType : {context.Exception.GetType()}");

            switch (context.Exception)
            {
                case EntityNotFoundException entityNotFound:
                    {

                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        var errorMessageage = _localizationManager.GetResource("EntityNotFound");
                        await context.HttpContext.Response.WriteAsync(errorMessageage);
                        break;
                    }
                case BlockedException blockedException:
                    {

                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var errorMessageage = _localizationManager.GetResource("CardBlocked");
                        await context.HttpContext.Response.WriteAsync(errorMessageage);
                        break;
                    }
                case LimitException limitException:
                    {
                        var message = limitException.Message;
                        var actionName = limitException.LimitAction;
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var errorMessageage = _localizationManager.GetResource("CardLimit");
                        await context.HttpContext.Response.WriteAsync(errorMessageage);
                        break;
                    }
                default:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var errorMessageage = _localizationManager.GetResource("UnhandeletedErrorOccurred");
                        await context.HttpContext.Response.WriteAsync(errorMessageage);
                        break;
                    }
            }
            context.ExceptionHandled = true; // this flag should be set to true to stop exception propagation
        }
    }
}