using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Velosaurus.Core.Middleware.ExceptionMiddleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _requestDelegate;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IExceptionHandler _exceptionHandler;

    // Default ExceptionHandler, if not registered in IoC container (program.cs), which it is :)
    public ExceptionMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionMiddleware> logger) : this(requestDelegate, logger, new ExceptionHandler()) { }

    public ExceptionMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionMiddleware> logger, IExceptionHandler exceptionHandler)
    {
        _requestDelegate = requestDelegate;
        _logger = logger;
        _exceptionHandler = exceptionHandler;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            var request = context.Request;
            // TODO remark structured logging
            _logger.LogInformation("Handling request: {method} {path} from {ip}",
                context.Request.Method,
                context.Request.Path,
                context.Connection.RemoteIpAddress?.ToString());
            await _requestDelegate(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "LogError: Exception while processing {path}: '{message}'",
                context.Request.Path,
                e.Message);
            _ = _exceptionHandler.HandleExceptionAsync(context, e);
        }
    }
}