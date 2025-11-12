using Application.Abstractions.DataAccess;
using Application.Abstractions.Messaging;
using SharedKernel;

namespace Application.User.Update;

internal sealed class PutUserCommandHandler(IDatabaseService database) : IQueryHandler<PutUserCommand>
{
    public async Task<Result> Handle(PutUserCommand command, CancellationToken cancellationToken)
    {
        await Task.Delay(10);

        UserDto userDto = command.user;
        Domain.Users.User user = Domain.Users.User.Create(userDto.FirstName,userDto.LastName,userDto.Email);
        
        database.Update(user);
        
        return Result.Success();
    }

}