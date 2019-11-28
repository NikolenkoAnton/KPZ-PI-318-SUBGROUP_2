using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using App.Configuration;
using App.Stocks.Exceptions;
using App.Stocks.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace App.Stocks.Filters
{
    public class StockExceptionFilter : IAsyncExceptionFilter, ITransientDependency
    {
        readonly ILocalizationManagerStocks _localizationManager;
        readonly ILogger<StockExceptionFilter> logger;
        public StockExceptionFilter(ILogger<StockExceptionFilter> logger, ILocalizationManagerStocks localizationManager)
        {
            this.logger = logger;
            _localizationManager = localizationManager;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            logger.LogError(context.Exception, $"Error occurred in context of ");
            switch (context.Exception)
            {
                case EntityNotExistException EntityNotExistException:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

                        logger.LogWarning($"Type : {EntityNotExistException.EntityType.AssemblyQualifiedName},EntityId {EntityNotExistException.EntityId}. Method: {EntityNotExistException.TargetSite}.");

                        await context.HttpContext.Response.WriteAsync($"Entity with id : {EntityNotExistException.EntityId} and type {EntityNotExistException.EntityType.AssemblyQualifiedName} not found!");
                        break;
                    }
                case IncorrectParamsFormatException incorrectParamsFormat:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        logger.LogWarning(incorrectParamsFormat, $"Param name: {incorrectParamsFormat.ParamName}. Method: {incorrectParamsFormat.TargetSite}");
                        await context.HttpContext.Response.WriteAsync($@"You send request with incorrect {incorrectParamsFormat.ParamName} format");
                        break;
                    }
                case СompanyStocksIsPrivateException сompanyStocksIsPrivate:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        logger.LogWarning(сompanyStocksIsPrivate, $"CompanyId: {сompanyStocksIsPrivate.CompanyId}. Method: {сompanyStocksIsPrivate.TargetSite}");
                        await context.HttpContext.Response.WriteAsync($"You cannot view information about these stocks.Company {сompanyStocksIsPrivate.CompanyName} has restricted access to stock information.");
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