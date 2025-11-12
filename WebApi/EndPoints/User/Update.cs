using Application.Abstractions.Messaging;
using Application.User;
using Application.User.Update;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.EndPoints.User;

public class Update :IEndpoint
{
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("user/update", (
            [FromBody] UserDto user,
            [FromServices]IQueryHandler<PutUserCommand> command,
            CancellationToken cancellationToken
        ) =>
        {
            var commandQuery = new PutUserCommand(user);
            return command.Handle(commandQuery, cancellationToken);
        });
    }
    
}