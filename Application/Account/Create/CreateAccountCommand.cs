using Application.Abstractions.Messaging;

namespace Application.Account.Create;

public sealed record CreateAccountCommand (string name,string email) : ICommand<AccountDto>
{
    
}