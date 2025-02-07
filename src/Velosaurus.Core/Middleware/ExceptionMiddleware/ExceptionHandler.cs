using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using Velosaurus.Core.Exceptions;
using Velosaurus.Core.ResponseObjects;

namespace Velosaurus.Core.Middleware.ExceptionMiddleware;

public class ExceptionHandler : IExceptionHandler
{
    public Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var problemDetails = CreateProblemDetails(context, exception);

        var response = JsonSerializer.Serialize(problemDetails);
        context.Response.StatusCode = (int)problemDetails.Status!;
        return context.Response.WriteAsync(response);
    }


    private VelosaurusProblemDetails CreateProblemDetails(HttpContext context, Exception exception)
    {
        var statusCode = (int)HttpStatusCode.InternalServerError;
        var title = "Internal Server Error";
        var detail = exception.Message;
        var instance = context.Request.Path;

        switch (exception)
        {
            case ItemNotFoundException itemNotFoundException:
                statusCode = (int)HttpStatusCode.NotFound;
                title = itemNotFoundException.ExceptionTitle;
                detail = itemNotFoundException.ExceptionDetail;
                break;
            case Exception genericException:
                statusCode = (int)HttpStatusCode.InternalServerError;
                title = genericException.Message;
                detail = genericException.Source;
                break;
        }

        return new VelosaurusProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
            Instance = instance
        };
    }
}
