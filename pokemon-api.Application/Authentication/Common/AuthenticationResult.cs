﻿
using pokemon_api.Domain.User;

namespace pokemon_api.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);