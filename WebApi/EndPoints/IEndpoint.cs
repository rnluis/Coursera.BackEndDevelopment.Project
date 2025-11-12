namespace WebApi.EndPoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}