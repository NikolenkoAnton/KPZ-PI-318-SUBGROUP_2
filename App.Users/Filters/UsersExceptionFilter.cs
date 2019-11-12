using App.Users.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace App.Users.Filters
{
    public class UsersExceptionFilter : IAsyncExceptionFilter
    {
        readonly string context;
        readonly ILogger<UsersExceptionFilter> logger;

        public UsersExceptionFilter(string context, ILogger<UsersExceptionFilter> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            logger.LogError(context.Exception, $"Error occurred in context of {this.context}");
            switch (context.Exception)
            {
                case EntityNotFoundException entityNotFound:
                    {
                        logger.LogWarning(entityNotFound, $"Method: {entityNotFound.TargetSite}");
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        await context.HttpContext.Response.WriteAsync($"User with id {entityNotFound.Id} not found");
                        break;
                    }
                case EntityUniqueViolatedException entityUniqueViolated:
                    {
                        logger.LogWarning(entityUniqueViolated, $"Method: {entityUniqueViolated.TargetSite}");
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.HttpContext.Response.WriteAsync($"User with id {entityUniqueViolated.Id} already exist");
                        break;
                    }
                case PasswordVerificationException passwordVerification:
                    {
                        logger.LogWarning(passwordVerification, $"Method: {passwordVerification.TargetSite}");
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.HttpContext.Response.WriteAsync($"Password verification for user with id {passwordVerification.Id} failed");
                        break;
                    }
                case UserAvailabilityException userAvailability:
                    {
                        logger.LogWarning(userAvailability, $"Method: {userAvailability.TargetSite}");
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.HttpContext.Response.WriteAsync($"Availability of user with id {userAvailability.Id} is already {userAvailability.Availability}");
                        break;
                    }
                default:
                    {
                        logger.LogError($"Method: {context.Exception.TargetSite}.");
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.HttpContext.Response.WriteAsync("Unhandled exception ! Please, contact support for resolve");
                        break;
                    }
            }
            context.ExceptionHandled = true;
        }
    }
}
