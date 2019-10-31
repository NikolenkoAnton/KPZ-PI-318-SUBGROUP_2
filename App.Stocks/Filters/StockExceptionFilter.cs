using App.Stocks.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Stocks.Filters
{
    public class StockExceptionFilter : IAsyncExceptionFilter
    {
        readonly string _context;
        readonly ILogger<StockExceptionFilter> logger;
        public StockExceptionFilter(ILogger<StockExceptionFilter> logger, string context)
        {
            this.logger = logger;
            _context = context;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            logger.LogError(context.Exception, $"Error occurred in context of {_context}");
            switch (context.Exception)
            {
                case EntityNotExist entityNotExist:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        logger.LogWarning($"Entity with type {entityNotExist.EntityType.AssemblyQualifiedName} not found!");
                        await context.HttpContext.Response.WriteAsync($"Entity with type {entityNotExist.EntityType.AssemblyQualifiedName} not found!");
                        break;
                    }
                case IncorrectStockDate incorrectDate:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        logger.LogWarning(incorrectDate,"Call method GetStockByDate with inccorect date");
                        await context.HttpContext.Response.WriteAsync($@"You input inccorect date : {incorrectDate.InccorectDate}.Please, input date which less or equal than {DateTime.Now.ToString()}");
                        break;
                    }
                case IncorrectParamsFormat incorrectParamsFormat:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                       // logger.LogWarning(incorrectDate, "Call method GetStockByDate with inccorect date");
                        await context.HttpContext.Response.WriteAsync($@"You send request with incorrect {incorrectParamsFormat.ParamName} format");
                        break;
                    }
                case СompanyStocksIsPrivate сompanyStocksIsPrivate:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        logger.LogWarning(сompanyStocksIsPrivate, "Call method GetCompanyStock with id company which has private stock");
                        await context.HttpContext.Response.WriteAsync($"You cannot view information about these stocks.Company {сompanyStocksIsPrivate.CompanyName} has restricted access to stock information.");
                        break;
                    }
                default:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.HttpContext.Response.WriteAsync("Unhandled exception ! Please, contact support for resolve");
                        break;
                    }
            }
            context.ExceptionHandled = true; // this flag should be set to true to stop exception propagation
        }


    }
}
