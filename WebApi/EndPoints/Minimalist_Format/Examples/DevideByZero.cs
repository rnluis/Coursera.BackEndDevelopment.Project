namespace WebApi.EndPoints.Minimalist_Format.Examples;


public class DevideByZero :IEndpoint
{
    private readonly ILogger<int> _logger;

    public DevideByZero(ILogger<int> logger)
    {
        _logger = logger;
    }
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Division/{Value:int}/{Divisor:int}", async (
            int Value,
            int Divisor,
            CancellationToken cancellationToken
            ) =>
        {
            
            int i = Value / Divisor ;

            return i;
        }).WithName("Get the Division of two numbers")
            .WithTags("Division");
    }
}