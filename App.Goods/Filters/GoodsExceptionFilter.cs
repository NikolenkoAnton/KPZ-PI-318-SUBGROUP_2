using System.Net;
using System.Threading.Tasks;
using App.Goods.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace App.Goods.Filters
{
    class GoodsExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<GoodsExceptionFilter> _logger;
        private readonly string _context;

        public GoodsExceptionFilter(ILogger<GoodsExceptionFilter> logger, string context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            _logger.LogError(context.Exception, $"Error ocurred in context of {_context}");

            switch (context.Exception)
            {
                case ProductNotFoundException productNotFound:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

                        string productIds = string.Join(", ", productNotFound.ProductIds);
                        await context.HttpContext.Response.WriteAsync($"Following product ids was not found: {productIds}");
                        break;
                    }
                case EmptyOrderException emptyOrder:
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.HttpContext.Response.WriteAsync(emptyOrder.Message);
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
