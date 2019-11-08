using App.Configuration;
using App.Deposits.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Deposits.Filters
{
    public class DepositExceptionFilter : IAsyncExceptionFilter
    {
        private readonly string context;
        private readonly ILogger<DepositExceptionFilter> logger;

        public DepositExceptionFilter(ILogger<DepositExceptionFilter> logger, string context)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            logger.LogError(context.Exception, $"Error occurred in context of {context}");

            switch (context.Exception)
            {
                case InvalidDataDTOException e:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                        logger.LogWarning($"{e.Message}. Method: {e.TargetSite}.");

                        await context.HttpContext.Response.WriteAsync(e.Message);
                        break;
                    }
                case EntityNotExistException e:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

                        logger.LogWarning($"Type : {e.EntityType.AssemblyQualifiedName},EntityId {e.EntityId}. Method: {e.TargetSite}.");

                        await context.HttpContext.Response.WriteAsync($"Entity with id : {e.EntityId} and type {e.EntityType.AssemblyQualifiedName} not found!");
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
