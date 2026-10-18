using Microsoft.AspNetCore.Diagnostics;

namespace GlobalExceptionHandling.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
    
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(
            ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(
                exception,
                "An unexpected error occurred.");

            httpContext.Response.StatusCode =
                StatusCodes.Status500InternalServerError;

            httpContext.Response.ContentType =
                "application/json";

            var response = new
            {
                statusCode = 500,
                message = "An unexpected error occurred.",
                traceId = httpContext.TraceIdentifier
            };

            await httpContext.Response.WriteAsJsonAsync(
                response,
                cancellationToken);

            return true;
        }
    }
}
 
