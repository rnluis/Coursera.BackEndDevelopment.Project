using Application.Abstractions.DataAccess;
using Application.Abstractions.Messaging;
using Application.Mapping;
using SharedKernel;

namespace Application.User.GetAll;

internal sealed class GetUserCommandHandler(IDatabaseService database) : IQueryHandler<GetUserCommand, List<UserDto>>
{
    public async Task<Result<List<UserDto>>> Handle(GetUserCommand command, CancellationToken cancellationToken)
    {
        await Task.Delay(10);

        List<Domain.Users.User> users = database.GetAll<Domain.Users.User>();
        
        return UserMapping.ToDtoList(users);
    }

}