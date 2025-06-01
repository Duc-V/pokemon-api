namespace pokemon_api.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Register(string firstName, string lastName, string username, string password)
    {
        return new AuthenticationResult( Guid.NewGuid(), firstName, lastName, username, password); ;
    }

    public AuthenticationResult Login(string username, string password)
    {
        return new AuthenticationResult( Guid.NewGuid(), "firstName", "lastName", username, password); ;
    }
    
    
}