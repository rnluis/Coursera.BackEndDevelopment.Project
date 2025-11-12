using Serilog;
using Serilog.Events;

namespace WebApi;

public class AuthenticationAuthorizationMiddleware(RequestDelegate next)
{

    public async Task Invoke(HttpContext httpContext)
    {

        if (httpContext.Request.Path == "/unauthorized")
        {
            httpContext.Response.StatusCode = 401;
            await httpContext.Response.WriteAsync("Unauthorized Access");
        }
        
        var isAuthenticated = httpContext.Request.Query["authenticated"] == "true";

        if (!isAuthenticated)
        {
            httpContext.Response.StatusCode = 403;
            await httpContext.Response.WriteAsync("Access Denied");
        }
        
        
        await next.Invoke(httpContext);
    }
    
}