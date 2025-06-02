using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using pokemon_api.Application.Common.Interfaces.Authentication;

namespace pokemon_api.Infrastructure.Authentication;

public class JwtTokenGenerator: IJwtTokenGenerator
{
    
    private readonly JwtSettings _settings;

    public JwtTokenGenerator(IOptions<JwtSettings> settings)
    {
        _settings = settings.Value;
    }
    
    public string GenerateToken(Guid usedId, string firstName, string lastName)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_settings.Secret)),
            SecurityAlgorithms.HmacSha256
        );
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, usedId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            expires: DateTime.Now.AddMinutes(_settings.ExpirationInMinutes),
            claims: claims,
            signingCredentials: signingCredentials
            
        );
        
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}