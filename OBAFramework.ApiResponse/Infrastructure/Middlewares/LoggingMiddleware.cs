using System.Security.Claims;
using System.Text;
using System.Text.Json;
using OBAFramework.Domain.Models;
using Serilog;

namespace OBAFramework.ApiResponse.Infrastructure.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestLogger _logger;

        public LoggingMiddleware(RequestDelegate next, IRequestLogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            await _logger.LogRequestAsync(context);
            await _next(context);
        }
    }
}
