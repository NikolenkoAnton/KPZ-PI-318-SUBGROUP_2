using System.Net;
using System.Threading.Tasks;
using App.News.Exceptions;
using App.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using App.News.Localization;

namespace App.News.Filters
{
    public class NewsExceptionFilter : IAsyncExceptionFilter, ITransientDependency
    {
        private readonly ILogger<NewsExceptionFilter> logger;
        readonly ILocalizationManager localizationManager;
        public NewsExceptionFilter(ILogger<NewsExceptionFilter> logger,ILocalizationManager localizationManager)
        {
            this.logger = logger;
            this.localizationManager = localizationManager;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            logger.LogError(context.Exception, $"Error occurred in context of {context}");
            switch (context.Exception)
            {
                case EntityNotFoundException entityNotFound:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        var errorMessage = localizationManager.GetResource("ResourceNotFound");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                case ValidationException validationException:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                        var errorMessage = localizationManager.GetResource(validationException.Message);
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                default:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var message = localizationManager.GetResource("UnhandeledException");
                        await context.HttpContext.Response.WriteAsync(message);
                        break;
                    }
            }
            context.ExceptionHandled = true;
        }
    }
}
