using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace TaskManagement.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            object response = new { error = exception.Message };

            if (exception is ApplicationException)
                statusCode = HttpStatusCode.BadRequest;
            else if (exception is UnauthorizedAccessException)
                statusCode = HttpStatusCode.Unauthorized;
            else if (exception is KeyNotFoundException)
                statusCode = HttpStatusCode.NotFound;
            else if (exception is ValidationException validationEx)
            {
                statusCode = HttpStatusCode.BadRequest;
                response = new { errors = validationEx.Message };
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
