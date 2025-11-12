using Application.Abstractions.Messaging;
using Application.Account.Create;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace WebApi.EndPoints.Controller_Format.Account;

[ApiController]
[Route("api/[controller]/")]
public class AccountController :ControllerBase
{
    [HttpPost("createaccount/{name}/{email}")]
    public async Task<ActionResult<AccountDto>> CreateAccount(
         ICommandHandler<CreateAccountCommand,AccountDto> handler,
         CancellationToken cancellationToken,
         [FromRoute] string name,
         [FromRoute] string email)
    {
        
        CreateAccountCommand command = new CreateAccountCommand(name, email);
        
        Result<AccountDto> result = await handler.Handle(command, cancellationToken);

        return Ok(result.Value);

    }
    
}