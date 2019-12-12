using System;
using System.Net;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Threading.Tasks;
using App.UserSupport.Exceptions;
using Microsoft.AspNetCore.Http;
using App.UserSupport.Localization;

namespace App.UserSupport.Filters
{
    public class UserSupportExceptionFilter : IAsyncExceptionFilter
    {
            readonly string _context;
            readonly ILogger<UserSupportExceptionFilter> logger;
        readonly ILocalizationManager _localizationManager;

        public UserSupportExceptionFilter(ILogger<UserSupportExceptionFilter> logger, string context, ILocalizationManager localizationManager)
            {
                this.logger = logger;
                _context = context;
            _localizationManager = localizationManager;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
            {
                logger.LogError(context.Exception, $"Error occurred in context of {_context}");
                switch (context.Exception)
                {
                    case HandlingAlreadyCompeletedException handlingAlredyComplete:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var errorMessage = _localizationManager.GetResource("Handling");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                case EntityNotFoundException entityNotFound:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        var errorMessage = _localizationManager.GetResource("ResourceNotFound");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                default:
                        {
                            logger.LogError($"Method: {context.Exception.TargetSite}.");

                            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var errorMessage = _localizationManager.GetResource("UnhandeledException");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                        }
                }
                context.ExceptionHandled = true;
            }

        }
    }

