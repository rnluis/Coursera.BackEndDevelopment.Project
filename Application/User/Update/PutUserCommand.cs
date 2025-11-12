using Application.Abstractions.Messaging;
using SharedKernel;

namespace Application.User.Update;

public sealed record PutUserCommand(UserDto user) : IQuery<Result>;
