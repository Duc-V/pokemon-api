using ErrorOr;
namespace pokemon_api.Application.Services.Authentication;
public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string username, string password);
    ErrorOr<AuthenticationResult> Login(string username, string password);
    
}