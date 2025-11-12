using System.Reflection;
using Application;
using Infrastructure;
using WebApi;
using WebApi.Extensions;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Logs/app.log", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error)
    .CreateLogger();

builder.Host.UseSerilog();


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure();

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.MapEndpoints();

app.MapGet("/", () => "Clean architecture template!");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/home/error");
}
else
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
    app.UseSwaggerUI(o => o.SwaggerEndpoint("/openapi/v1.json", "v1"));
}


//Middlewares
app.UseRequestContextLoggingMiddleware();
app.UsePreValidationsMiddleware();

app.Use(async (context, next) =>

    {
        await Task.Delay(1);
        Log.Write(LogEventLevel.Information,"Processed Asynchronously");
        await next.Invoke();
    }

);




//app.UseHttpsRedirection();
// Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
