using Microsoft.AspNetCore.Http;

namespace Velosaurus.Core.Middleware.ExceptionMiddleware;

public interface IExceptionHandler
{
    Task HandleExceptionAsync(HttpContext context, Exception exception);
}