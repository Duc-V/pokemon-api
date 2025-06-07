using ErrorOr;
using MediatR;
using pokemon_api.Application.Authentication.Common;
using pokemon_api.Application.Common.Interfaces.Authentication;
using pokemon_api.Application.Common.Interfaces.Persistence;
using pokemon_api.Domain.Common.Errors;
using pokemon_api.Domain.Entities;

namespace pokemon_api.Application.Authentication.Commands.Register;

// handle the command  
public class RegisterCommandHandler: // Inherit IRequest handler, handle RegisterCommand, and response with ErrorOr Auth
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserByEmail(command.Email) != null)
        {
            return Errors.User.DuplicatedEmail;
        }
        // Create a user
        var user = new User {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password, 
        };
        
        _userRepository.AddUser(user);
        // Create Jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(user, token); 

    }
}