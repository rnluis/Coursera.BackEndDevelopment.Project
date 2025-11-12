using Application.Abstractions.Messaging;
using Application.User;
using Application.User.Add;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.EndPoints.User;

public class Add :IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("user/add/", (
            [FromBody] UserDto user,
            [FromServices]IQueryHandler<PostUserCommand,Guid> command,
            CancellationToken cancellationToken
        ) =>
        {

            var commandQuery = new PostUserCommand(user);

            return command.Handle(commandQuery, cancellationToken);
        });
    }
}