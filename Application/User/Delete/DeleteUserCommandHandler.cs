using Application.Abstractions.DataAccess;
using Application.Abstractions.Messaging;
using SharedKernel;

namespace Application.User.Delete;

internal sealed class DeleteUserCommandHandler(IDatabaseService database) : IQueryHandler<DeleteUserCommand>
{
    public async Task<Result> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        await Task.Delay(10);

        database.Delete<Domain.Users.User>(command.id);
        
        return Result.Success();
    }

}