using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using App.Cards.Exceptions;

namespace App.Example.Filters
{
    /// <summary>
    /// Example of async exception filter.
    /// The purpose of this class -> catch unhandeled exceptions and wrap sensitive data into common form
    /// </summary>
    public class CardsExceptionFilter : IAsyncExceptionFilter
    {
        readonly string _context;
        readonly ILogger<CardsExceptionFilter> logger;
        public CardsExceptionFilter(ILogger<CardsExceptionFilter> logger, string context)
        {
            this.logger = logger;
            _context = context;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            logger.LogError(context.Exception, $"Error occurred in context of {_context}");
            logger.LogWarning($"ErrorType : {context.Exception.GetType()}");

            switch (context.Exception)
            {
                case EntityNotFoundException entityNotFound:
                    {
                        logger.LogWarning($"ErrorType : {entityNotFound.GetType()}");

                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        await context.HttpContext.Response.WriteAsync($"Not Found: {entityNotFound.EntityType.AssemblyQualifiedName}");
                        break;
                    }
                case BlockedException blockedException:
                    {

                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.HttpContext.Response.WriteAsync($"Card's with id {blockedException.CardId} is blocked!");
                        break;
                    }
                case LimitException limitException:
                    {
                        var message = limitException.Message;
                        var actionName = limitException.LimitAction;
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.HttpContext.Response.WriteAsync($"Invalid {actionName} opertation.Details: {message}");
                        break;
                    }
                default:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.HttpContext.Response.WriteAsync("Unhandled exception ! Please, contact support for resolve");
                        break;
                    }
            }
            context.ExceptionHandled = true; // this flag should be set to true to stop exception propagation
        }
    }
}