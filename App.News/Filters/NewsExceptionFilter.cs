using System.Net;
using System.Threading.Tasks;
using App.News.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace App.News.Filters
{
    public class NewsExceptionFilter : ExceptionFilterAttribute, IAsyncExceptionFilter
    {
        readonly string context;
        readonly ILogger<NewsExceptionFilter> logger;
        public NewsExceptionFilter(ILogger<NewsExceptionFilter> logger, string context)
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            logger.LogError(context.Exception, $"Error occurred in context of {context}");
            switch (context.Exception)
            {
                case EntityNotFoundException entityNotFound:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        await context.HttpContext.Response.WriteAsync($"Not Found: {entityNotFound.EntityType.AssemblyQualifiedName}");
                        break;
                    }
                case ValidationException validationException:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                        await context.HttpContext.Response.WriteAsync("Some necessary fields are not filled!");
                        break;
                    }
                default:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.HttpContext.Response.WriteAsync("Unhandled exception ! Please, contact support for resolve");
                        break;
                    }
            }
            context.ExceptionHandled = true;
        }
    }
}
