using Serilog;
using Serilog.Events;

namespace WebApi.Middleware;

public class RequestContextLoggingMiddleware(RequestDelegate next)
{

    public async Task Invoke(HttpContext httpContext)
    {
        // TODO: Logging Middleware

        try
        {
            Log.Write(LogEventLevel.Information, "Request Path:"+httpContext.Request.Path);
            Log.Write(LogEventLevel.Information, "Request Method:"+httpContext.Request.Method);
            await next.Invoke(httpContext);
            Log.Write(LogEventLevel.Information, "Final Response from app");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Global Exception Caught:" + ex.Message);
            httpContext.Response.StatusCode = 500;
            await httpContext.Response.WriteAsync("Global Exception Caught:" + ex.Message);
        }
        finally
        {
            
            var status = httpContext.Response.StatusCode;

            if (status >= 400 && status < 500)
            {
                
                Log.Write(LogEventLevel.Error,"400+ Error found:");
                Log.Write(LogEventLevel.Error,"     "+httpContext.Response.Body);
                
                
            }
            
        }
        
    }
    
}
