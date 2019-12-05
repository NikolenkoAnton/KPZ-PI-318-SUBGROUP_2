using App.Deposits.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using App.Deposits.Localization;

namespace App.Deposits.Filters
{
    public class DepositExceptionFilter : IAsyncExceptionFilter
    {
        private readonly string context;
        private readonly ILogger<DepositExceptionFilter> logger;
        private readonly ILocalizationManager localizationManager;

        public DepositExceptionFilter(ILogger<DepositExceptionFilter> logger, string context, ILocalizationManager localizationManager)
        {
            this.context = context;
            this.logger = logger;
            this.localizationManager = localizationManager;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            logger.LogError(context.Exception, $"Error occurred in context of {context}");

            switch (context.Exception)
            {
                case InvalidDataDTOException e:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                        var errorMessage = localizationManager.GetResource("InvalidDataDTO");

                        logger.LogWarning($"{e.Message}. Method: {e.TargetSite}.");
                        
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                case EntityNotExistException e:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

                        var errorMessage = localizationManager.GetResource("EntityNotExist");

                        logger.LogWarning($"Type : {e.EntityType.AssemblyQualifiedName},EntityId {e.EntityId}. Method: {e.TargetSite}.");

                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                default:
                    {
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
