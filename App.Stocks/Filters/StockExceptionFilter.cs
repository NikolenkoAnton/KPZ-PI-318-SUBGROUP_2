using App.Stocks.Exceptions;
using App.Stocks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private int GetCompanyIdParamFromPathRequest(ExceptionContext context)
        {
            var companyId = Convert.ToInt32(context
                                    .HttpContext
                                    .Request
                                    .Path
                                    .Value
                                    .Split('/')
                                    .Where(x => Int32.TryParse(x, out int id))
                                    .FirstOrDefault());
            return companyId;

        }
        private int GetStockIdParamFromPathRequest(ExceptionContext context)
        {
            var stockId = Convert.ToInt32(context
                                    .HttpContext
                                    .Request
                                    .Path
                                    .Value
                                    .Split('/')
                                    .Where(x => Int32.TryParse(x, out int id))
                                    .Skip(1)
                                    .FirstOrDefault());
            return stockId;

        }
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            logger.LogError(context.Exception, $"Error occurred in context of {_context}");
            switch (context.Exception)
            {
                case EntityNotExist entityNotExist:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

                        int entityId = 0;
                        var entityType = entityNotExist.EntityType;

                        if (entityType.Equals(typeof(Company)))
                        {
                            entityId = GetCompanyIdParamFromPathRequest(context);
                        }

                        if (entityType.Equals(typeof(Stock)))
                        {
                            entityId = GetStockIdParamFromPathRequest(context);
                        }

                        logger.LogWarning($"Type : {entityNotExist.EntityType.AssemblyQualifiedName}, Id {entityId}. Method: {entityNotExist.TargetSite}.");

                        await context.HttpContext.Response.WriteAsync($"Entity with id : {entityId} and type {entityNotExist.EntityType.AssemblyQualifiedName} not found!");
                        break;
                    }
                case IncorrectStockDate incorrectStockDate:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        logger.LogWarning(incorrectStockDate, $"Incorrect date in reques! Method: {incorrectStockDate.TargetSite}");
                        await context.HttpContext.Response.WriteAsync($@"You input date, which more than today date: {incorrectStockDate.InccorectDate}.Please, input date which less or equal than {DateTime.Now.ToString()}");
                        break;
                    }
                case IncorrectParamsFormat incorrectParamsFormat:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        logger.LogWarning(incorrectParamsFormat, $"Param name: {incorrectParamsFormat.ParamName}. Method: {incorrectParamsFormat.TargetSite}");
                        await context.HttpContext.Response.WriteAsync($@"You send request with incorrect {incorrectParamsFormat.ParamName} format");
                        break;
                    }
                case СompanyStocksIsPrivate сompanyStocksIsPrivate:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        var companyId = GetCompanyIdParamFromPathRequest(context);
                        logger.LogWarning(сompanyStocksIsPrivate, $"CompanyId: {companyId}. Method: {сompanyStocksIsPrivate.TargetSite}");
                        await context.HttpContext.Response.WriteAsync($"You cannot view information about these stocks.Company {сompanyStocksIsPrivate.CompanyName} has restricted access to stock information.");
                        break;
                    }
                default:
                    {
                        logger.LogWarning($"Method: {context.Exception.TargetSite}.");

                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.HttpContext.Response.WriteAsync("Unhandled exception ! Please, contact support for resolve");
                        break;
                    }
            }
            context.ExceptionHandled = true; 
        }


    }
}
