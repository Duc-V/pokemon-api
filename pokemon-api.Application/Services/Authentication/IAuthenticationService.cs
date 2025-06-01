namespace pokemon_api.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Register(string firstName, string lastName, string username, string password);
    AuthenticationResult Login(string username, string password);
    
}