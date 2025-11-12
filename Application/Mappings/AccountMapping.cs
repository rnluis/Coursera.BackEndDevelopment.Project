using Application.Account.Create;

namespace Application.Mappings;

public static class AccountMapping
{

    public static AccountDto AccountToDto(this Domain.Account.Account account)
    {
        return new AccountDto(
            account.Id,
            account.Name,
            account.Email);
    }
    
}