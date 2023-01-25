using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SampleProject.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggerMiddleware2
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggerMiddleware2(RequestDelegate next, ILoggerFactory logFactory)
        {
            _logger = logFactory.CreateLogger("MyMiddleware 2");
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            _logger.LogInformation("start Middleware 2");
            await _next(httpContext);
            _logger.LogInformation("End Middleware 2");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoggerMiddleware2Extensions
    {
        public static IApplicationBuilder UseLoggerMiddleware2(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerMiddleware2>();
        }
    }
}
