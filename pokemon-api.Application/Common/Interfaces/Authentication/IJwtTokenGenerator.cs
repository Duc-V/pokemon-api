
using pokemon_api.Domain.User;

namespace pokemon_api.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}