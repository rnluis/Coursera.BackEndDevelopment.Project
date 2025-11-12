using Application.Abstractions.Messaging;

namespace Application.User.Delete;

public sealed record DeleteUserCommand(Guid id) : IQuery;
