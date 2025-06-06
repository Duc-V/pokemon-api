using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;
using pokemon_api.Application.Authentication.Commands.Register;
using pokemon_api.Application.Authentication.Common;
using pokemon_api.Application.Authentication.Query.Login;
using pokemon_api.Contracts.Authentication;


namespace pokemon_api.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController: ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {   
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }
    

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        
        var query = new LoginQuery(request.Email, request.Password);
        
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
        
        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }
    
    
    
    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );
    }
}