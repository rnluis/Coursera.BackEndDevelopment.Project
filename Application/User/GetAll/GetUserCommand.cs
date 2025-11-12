using Application.Abstractions.Messaging;

namespace Application.User.GetAll;

public sealed record GetUserCommand : IQuery<List<UserDto>>;
