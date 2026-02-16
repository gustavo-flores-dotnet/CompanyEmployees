using Contracts;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace CompanyEmployees;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILoggerManager _logger;
    public GlobalExceptionHandler(ILoggerManager logger)
    {
        _logger = logger;
    }
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception expception,
        CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/json";

        var contextFeature = httpContext.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            _logger.LogError($"Something went wrong: {contextFeature.Error}");
            await httpContext.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = "Internal Server Error.",
            }.ToString());
        }
        return true;
    }
}
