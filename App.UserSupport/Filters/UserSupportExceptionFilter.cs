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
                    case HandlingAlreadyCompeletedException handlingAlredyComplete:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.HttpContext.Response.WriteAsync($"Handling with id {handlingAlredyComplete.HandlingId} is already complete!");
                        break;
                    }
                case EntityNotFoundException entityNotFound:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        await context.HttpContext.Response.WriteAsync($"Not Found: {entityNotFound.EntityType.AssemblyQualifiedName}");
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

