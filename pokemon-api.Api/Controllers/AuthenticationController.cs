using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using pokemon_api.Application.Authentication.Commands.Register;
using pokemon_api.Application.Authentication.Common;
using pokemon_api.Application.Authentication.Quries.Login;
using pokemon_api.Contracts.Authentication;


namespace pokemon_api.Api.Controllers;

[ApiController]
[Route("auth")]
[AllowAnonymous]
public class AuthenticationController: ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {   
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
    

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        
        var query = _mapper.Map<LoginQuery>(request);
        
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
        
        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
    
} 