using pokemon_api.Application.Common.Interfaces.Authentication;

namespace pokemon_api.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{   
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {   
        // Check if user already exist
        // Create a user
        // Create Jwt token
        var id = Guid.NewGuid();
        
        var token = _jwtTokenGenerator.GenerateToken(id ,firstName, lastName);
        
        return new AuthenticationResult( id , firstName, lastName, email, token); 
    }

    public AuthenticationResult Login(string username, string password)
    {
        return new AuthenticationResult( Guid.NewGuid(), "firstName", "lastName", username, password); ;
    }
    
    
}