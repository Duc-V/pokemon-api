using pokemon_api.Application.Common.Interfaces.Authentication;
using pokemon_api.Application.Common.Interfaces.Persistence;
using ErrorOr;
using pokemon_api.Domain.Common.Errors;
using pokemon_api.Domain.Entities;

namespace pokemon_api.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{   
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public ErrorOr<AuthenticationResult>Register(string firstName, string lastName, string email, string password)
    {   
        // Check if user already exist
        if (_userRepository.GetUserByEmail(email) != null)
        {
            return Errors.User.DuplicatedEmail;
        }
        // Create a user
        var user = new User {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        
        _userRepository.AddUser(user);
        // Create Jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(user, token); 
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    { 
        // Validate the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        
        return new AuthenticationResult(user, token);
    }
    
    
}