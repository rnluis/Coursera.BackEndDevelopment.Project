using Application.Abstractions.Messaging;

namespace Application.User.Add;

public sealed record PostUserCommand(UserDto user) : IQuery<Guid>;
