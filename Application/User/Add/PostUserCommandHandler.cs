using Application.Abstractions.DataAccess;
using Application.Abstractions.Messaging;
using SharedKernel;

namespace Application.User.Add;

internal sealed class PostUserCommandHandler(IDatabaseService database) : IQueryHandler<PostUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(PostUserCommand command, CancellationToken cancellationToken)
    {
        await Task.Delay(10);

        UserDto userDto = command.user;

        Domain.Users.User user = Domain.Users.User.Create(userDto.FirstName,userDto.LastName,userDto.Email);

        Guid id = database.Add(user);
        
        return id;
    }

}