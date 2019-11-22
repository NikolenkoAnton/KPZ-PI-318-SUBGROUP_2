using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using App.Loans.Exceptions;
using Microsoft.AspNetCore.Http;

namespace App.Loans.Filters
{
    public class LoansExceptionsFilter : IAsyncExceptionFilter
    {
        readonly string _context;
        readonly ILogger<LoansExceptionsFilter> logger;
        public LoansExceptionsFilter(ILogger<LoansExceptionsFilter> logger, string context)
        {
            this.logger = logger;
            _context = context;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            logger.LogError(context.Exception, $"Error occurred in context of {_context}");
            switch (context.Exception)
            {
                case LoanAlreadyPaidException LoanAlreadyPaid:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.HttpContext.Response.WriteAsync($"Loan with id {LoanAlreadyPaid.LoanId} is already paid!");
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

