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
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        await context.HttpContext.Response.WriteAsync($"User with id {entityNotFound.Id} not found");
                        break;
                    }
                case EntityUniqueViolatedException entityUniqueViolated:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.HttpContext.Response.WriteAsync($"User with id {entityUniqueViolated.Id} already exist");
                        break;
                    }
                case PasswordVerificationException passwordVerification:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.HttpContext.Response.WriteAsync($"Password verification for user with id {passwordVerification.Id} failed");
                        break;
                    }
                case UserAvailabilityException userAvailability:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.HttpContext.Response.WriteAsync($"Availability of user with id {userAvailability.Id} already changed to {userAvailability.Availability}");
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
