using System;
using System.Net;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Threading.Tasks;
using App.UserSupport.Exceptions;
using Microsoft.AspNetCore.Http;

namespace App.UserSupport.Filters
{
    public class UserSupportExceptionFilter : IAsyncExceptionFilter
    {
            readonly string _context;
            readonly ILogger<UserSupportExceptionFilter> logger;
            public UserSupportExceptionFilter(ILogger<UserSupportExceptionFilter> logger, string context)
            {
                this.logger = logger;
                _context = context;
            }

            public async Task OnExceptionAsync(ExceptionContext context)
            {
                logger.LogError(context.Exception, $"Error occurred in context of {_context}");
                switch (context.Exception)
                {
                    case ClientAlredyExistException clientAlredyExist:
                        {
                            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

                            logger.LogWarning($"Type : {clientAlredyExist.EntityType.AssemblyQualifiedName},EntityId {EntityNotExistException.EntityId}. Method: {EntityNotExistException.TargetSite}.");

                            await context.HttpContext.Response.WriteAsync($"Entity with id : {EntityNotExistException.EntityId} and type {EntityNotExistException.EntityType.AssemblyQualifiedName} not found!");
                            break;
                        }
                    case InvalidArgumentException invalidArgument:
                        {
                            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            logger.LogWarning(invalidArgument, $"Argument name: {invalidArgument.ParamName}. Method: {invalidArgument.TargetSite}");
                            await context.HttpContext.Response.WriteAsync($@"You send request with incorrect {invalidArgument.ParamName} format");
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
}
