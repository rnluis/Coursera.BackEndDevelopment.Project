using Application.Abstractions.Messaging;
using Application.Mappings;
using SharedKernel;

namespace Application.Account.Create;

internal sealed class CreateAccountCommandHandler :ICommandHandler<CreateAccountCommand,AccountDto>
{
    public async Task<Result<AccountDto>> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
    {
        Domain.Account.Account account = new Domain.Account.Account(command.name, command.email);

        return AccountMapping.AccountToDto(account);
    }
}