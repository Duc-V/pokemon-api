namespace pokemon_api.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid usedId, string firstName, string lastName);
}