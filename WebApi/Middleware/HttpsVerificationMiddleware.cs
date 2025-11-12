namespace WebApi;

public class HttpsVerificationMiddleware(RequestDelegate next)
{

    public async Task Invoke(HttpContext httpContext)
    {
        if (httpContext.Request.Query["secure"] != "true")
        {
            httpContext.Response.StatusCode = 401;
            await httpContext.Response.WriteAsync("Simulated HTTPS Required");
            return;
        }
        
        await next.Invoke(httpContext);
    }
    
}