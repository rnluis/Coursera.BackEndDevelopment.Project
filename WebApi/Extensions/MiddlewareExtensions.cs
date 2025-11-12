using Microsoft.AspNetCore.Authentication;
using Serilog;
using Serilog.Events;
using WebApi.Middleware;

namespace WebApi.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseRequestContextLoggingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<RequestContextLoggingMiddleware>();
        return app;
    }

    public static IApplicationBuilder UsePreValidationsMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<HttpsVerificationMiddleware>();
        app.UseMiddleware<AuthenticationAuthorizationMiddleware>();
        return app;
    }
}