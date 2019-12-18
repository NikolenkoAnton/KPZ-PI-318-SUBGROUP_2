using App.Configuration;
using App.Users.Exception;
using App.Users.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace App.Users.Filter
{
    public class UsersExceptionFilter : IAsyncExceptionFilter, ITransientDependency
    {
        private readonly ILogger<UsersExceptionFilter> logger;
        private readonly ILocalizationManager localizationManager;

        public UsersExceptionFilter(ILogger<UsersExceptionFilter> logger, ILocalizationManager localizationManager)
        {
            this.logger = logger;
            this.localizationManager = localizationManager;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            logger.LogError(context.Exception, $"Error occurred in context of {context.ActionDescriptor.DisplayName}");
            switch (context.Exception)
            {
                case EntityNotFoundException entityNotFound:
                    {
                        logger.LogWarning(entityNotFound, $"Method: {entityNotFound.TargetSite}");
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        var errorMessage = localizationManager.GetResource("EntityNotFound");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                case BadRequestException badRequestException:
                    {
                        logger.LogWarning(badRequestException, $"Method: {badRequestException.TargetSite}");
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var errorMessage = localizationManager.GetResource("UnableProcessUser");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                default:
                    {
                        logger.LogError($"Method: {context.Exception.TargetSite}.");
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var errorMessage = localizationManager.GetResource("UnhandledException");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
            }
            context.ExceptionHandled = true;
        }
    }
}
