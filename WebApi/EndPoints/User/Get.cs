using Application.Abstractions.Messaging;
using Application.User;
using Application.User.GetAll;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using WebApi.Extensions;
using WebApi.Infrastructure;

namespace WebApi.EndPoints.User;

internal sealed class Get:IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("user/all", async (
                    [FromServices]IQueryHandler<GetUserCommand,List<UserDto>> handler,
                    CancellationToken cancelationToken) =>
                {

                    var command = new GetUserCommand();
                
                    Result<List<UserDto>> result = await handler.Handle(command,cancelationToken);;

                    return result.Match(Results.Ok, CustomResults.Problem);

                }
            ).WithName("GetUser")
            .WithTags("User");
    }
}