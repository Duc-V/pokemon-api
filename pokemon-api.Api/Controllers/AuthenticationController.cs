using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using pokemon_api.Application.Services.Authentication;
using pokemon_api.Contracts.Authentication;
using static pokemon_api.Api.Controllers.ApiController;

namespace pokemon_api.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController: ApiController
{
    
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {   
        _authenticationService = authenticationService;
    }
    
    
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {   
        ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(
            request.FirstName,
            request.LastName, 
   request.Email,
            request.Password);

        return authResult.Match(
            authResult => Ok(authResult),
            errors => Problem(errors));
    }
    

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        
        var authResult = _authenticationService.Login(request.Email, request.Password);
        
        ErrorOr<AuthenticationResult> authResult2 = _authenticationService.Login(request.Email, request.Password);
        
        return authResult.Match(
            authResult => Ok(authResult),
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