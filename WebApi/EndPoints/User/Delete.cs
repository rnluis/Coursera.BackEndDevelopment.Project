using Application.Abstractions.Messaging;
using Application.User.Delete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.EndPoints.User;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("user/delete/{id:Guid}", (
            [FromRoute]Guid id,
            [FromServices]IQueryHandler<DeleteUserCommand> command,
            CancellationToken cancellationToken
            ) =>
        {

            var commandQuery = new DeleteUserCommand(id);

            return command.Handle(commandQuery, cancellationToken);
        });
    }
}