using System.Net;
using System.Threading.Tasks;
using App.Goods.Exceptions;
using App.Goods.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace App.Goods.Filters
{
    class GoodsExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<GoodsExceptionFilter> _logger;
        private readonly ILocalizationManager _localizationManager;

        public GoodsExceptionFilter(ILogger<GoodsExceptionFilter> logger, ILocalizationManager localizationManager)
        {
            _logger = logger;
            _localizationManager = localizationManager;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            string contexName = context.ActionDescriptor.DisplayName;

            _logger.LogError(context.Exception, $"Error ocurred in context of {contexName}");

            switch (context.Exception)
            {
                case ProductNotFoundException productNotFound:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

                        string productIds = string.Join(", ", productNotFound.ProductIds);
                        var errorMessage = _localizationManager.GetResource("ProductNotFound") + productIds;
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                case EmptyOrderException emptyOrder:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var errorMessage = _localizationManager.GetResource(emptyOrder.Message);
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
                default:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var errorMessage = _localizationManager.GetResource("UnhandledException");
                        await context.HttpContext.Response.WriteAsync(errorMessage);
                        break;
                    }
            }

            context.ExceptionHandled = true;
        }
    }
}
