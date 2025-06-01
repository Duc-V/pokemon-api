namespace pokemon_api.Contracts.Authentication;

public record LoginRequest(
    string Email,
    string Password                             
);