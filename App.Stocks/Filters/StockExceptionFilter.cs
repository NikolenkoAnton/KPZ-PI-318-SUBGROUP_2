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
        readonly ILogger<StockExceptionFilter> logger;
        readonly ILocalizationManager _localizationManager;

        public StockExceptionFilter(ILocalizationManager localizationManager, ILogger<StockExceptionFilter> logger)
        {
            this.logger = logger;
            _localizationManager = localizationManager;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var _context = context.ActionDescriptor.DisplayName;
            logger.LogError(context.Exception, $"Error occurred in context of ");
            switch (context.Exception)
            {
                case EntityNotExistException EntityNotExistException:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

                        logger.LogWarning($"Type : {EntityNotExistException.EntityType.AssemblyQualifiedName},EntityId {EntityNotExistException.EntityId}. Method: {EntityNotExistException.TargetSite}.");
                        var errorMessageage = _localizationManager.GetResource("EntityNotExists");

                        await context.HttpContext.Response.WriteAsync(errorMessageage);
                        break;
                    }
                case IncorrectParamsFormatException incorrectParamsFormat:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        logger.LogWarning(incorrectParamsFormat, $"Param name: {incorrectParamsFormat.ParamName}. Method: {incorrectParamsFormat.TargetSite}");
                        var errorMessageage = _localizationManager.GetResource("IncorrectParamsFormat");
                        await context.HttpContext.Response.WriteAsync(errorMessageage);
                        break;

                    }
                case СompanyStocksIsPrivateException сompanyStocksIsPrivate:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        logger.LogWarning(сompanyStocksIsPrivate, $"CompanyId: {сompanyStocksIsPrivate.CompanyId}. Method: {сompanyStocksIsPrivate.TargetSite}");
                        var errorMessage = _localizationManager.GetResource("СompanyStocksIsPrivate");

                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                default:
                    {
                        logger.LogError($"Method: {context.Exception.TargetSite}.");
                        var errorMessageage = _localizationManager.GetResource("Unhandeled");

                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.HttpContext.Response.WriteAsync(errorMessageage);
                        break;
                    }
            }
            context.ExceptionHandled = true;
        }

    }
}