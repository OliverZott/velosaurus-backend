using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Velosaurus.Core.Middleware.ExceptionMiddleware;

public class ExceptionMiddleware(
    RequestDelegate requestDelegate,
    ILogger<ExceptionMiddleware> logger,
    IExceptionHandler exceptionHandler)
{
    // Default ExceptionHandler, if not registered in IoC container (program.cs), which it is :)
    public ExceptionMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionMiddleware> logger) : this(requestDelegate, logger, new ExceptionHandler()) { }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            var request = context.Request;

            logger.LogInformation("Handling request: {method} {path} from {ip}",
                context.Request.Method,
                context.Request.Path,
                context.Connection.RemoteIpAddress?.ToString());

            await requestDelegate(context);
        }
        catch (Exception e)
        {
            logger.LogError(e, "LogError: Exception while processing {path}: '{message}'",
                context.Request.Path,
                e.Message);
            _ = exceptionHandler.HandleExceptionAsync(context, e);
        }
    }
}