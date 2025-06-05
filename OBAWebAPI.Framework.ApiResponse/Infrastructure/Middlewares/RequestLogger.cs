using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace OBAWebAPI.Framework.ApiResponse.Infrastructure.Middlewares
{
    public interface IRequestLogger
    {
        Task LogRequestAsync(HttpContext context);
    }
    public class RequestLogger : IRequestLogger
    {
        private readonly ILogger<RequestLogger> _logger;

        public RequestLogger(ILogger<RequestLogger> logger)
        {
            _logger = logger;
        }

        public async Task LogRequestAsync(HttpContext context)
        {
            var request = context.Request;
            var user = context.User;

            request.EnableBuffering();

            var body = string.Empty;
            if (request.ContentLength > 0)
            {
                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer, 0, buffer.Length);
                request.Body.Position = 0;
                body = Encoding.UTF8.GetString(buffer);
            }

            var log = new
            {
                request.Method,
                request.Path,
                request.QueryString,
                Origin = request.Headers["Origin"].ToString(),
                Body = body,
                UserId = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
                Username = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value
            };

            _logger.LogInformation(JsonSerializer.Serialize(log));
        }
    }
}
