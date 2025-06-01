﻿namespace pokemon_api.Contracts.Authentication;

public record RegisterRequest(
    
    string FirstName,
    string LastName,
    string Email,
    string Password
);
