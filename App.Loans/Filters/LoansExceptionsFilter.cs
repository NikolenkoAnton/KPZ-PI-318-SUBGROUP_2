using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using App.Loans.Exceptions;
using Microsoft.AspNetCore.Http;
using App.Loans.Localization;

namespace App.Loans.Filters
{
    public class LoansExceptionsFilter : IAsyncExceptionFilter
    {
        readonly string _context;
        readonly ILogger<LoansExceptionsFilter> logger;
        readonly ILocalizationManager _localizationManager;

        public LoansExceptionsFilter(ILogger<LoansExceptionsFilter> logger, string context, ILocalizationManager localizationManager)
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
                case LoanAlreadyPaidException LoanAlreadyPaid:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var errorMessage = _localizationManager.GetResource("Loanpaid");
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

