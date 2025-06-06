﻿namespace pokemon_api.Infrastructure.Authentication;

public class JwtSettings
{
    public const string Section = "JwtSettings";
    public string Secret { get; set; } = null!;
    public int ExpirationInMinutes { get; set; }
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
}