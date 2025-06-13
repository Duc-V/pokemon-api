using ErrorOr;
using MediatR;
using pokemon_api.Application.Authentication.Common;
using pokemon_api.Application.Common.Interfaces.Authentication;
using pokemon_api.Application.Common.Interfaces.Persistence;
using pokemon_api.Domain.Common.Errors;
using pokemon_api.Domain.User;

namespace pokemon_api.Application.Authentication.Quries.Login;

public class LoginQueryHandler:
    IRequestHandler<LoginQuery,ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {   
        await Task.CompletedTask;
        
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        
        return new AuthenticationResult(user, token);

    }
}