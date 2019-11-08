using App.Bills.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Bills.Filters
{
    class BillsExceptionFilter : IAsyncExceptionFilter
    {
        readonly string _context;
        readonly ILogger<BillsExceptionFilter> logger;
        public BillsExceptionFilter(ILogger<BillsExceptionFilter> logger, string context)
        {
            this.logger = logger;
            _context = context;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            logger.LogError(context.Exception, $"Error occurred in context of {_context}");

            switch (context.Exception)
            {
                case EntityNotFoundException entityNotFound:
                    {

                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        await context.HttpContext.Response.WriteAsync($"Not Found: {entityNotFound.EntityType.AssemblyQualifiedName}");
                        break;
                    }
                case BillAlreadyBlockedException blockedException:
                    {

                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.HttpContext.Response.WriteAsync($"Bill with id {blockedException.BillId} is blocked!");
                        break;
                    }
                case BillAlreadyUnlockedException unlockedException:
                    {

                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.HttpContext.Response.WriteAsync($"Bill with id {unlockedException.BillId} is unblocked!");
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
