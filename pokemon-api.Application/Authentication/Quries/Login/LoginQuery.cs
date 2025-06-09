using ErrorOr;
using MediatR;
using pokemon_api.Application.Authentication.Common;

namespace pokemon_api.Application.Authentication.Quries.Login;

public record LoginQuery(
        string Email,
        string Password
): IRequest<ErrorOr<AuthenticationResult>>;