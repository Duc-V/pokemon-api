using ErrorOr;
using MediatR;
using pokemon_api.Application.Authentication.Common;

namespace pokemon_api.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName, // Data that needed to pass in the mediatR
    string LastName,
    string Email,
    string Password
): IRequest<ErrorOr<AuthenticationResult>>; // return type