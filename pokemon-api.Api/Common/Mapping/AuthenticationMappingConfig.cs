﻿using Mapster;
using pokemon_api.Application.Authentication.Commands.Register;
using pokemon_api.Application.Authentication.Common;
using pokemon_api.Application.Authentication.Quries.Login;
using pokemon_api.Contracts.Authentication;

namespace pokemon_api.Api.Common.Mapping;

public class AuthenticationMappingConfig: IRegister 
{
    public void Register(TypeAdapterConfig config)
    {   
        // Mapping from Authentication Result to Authenticatio Response
        // dest is Auth Response, and src is Auth Result
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest.FirstName, src => src.User.FirstName)
            .Map(dest => dest.LastName, src => src.User.LastName)
            .Map(dest => dest.Email, src => src.User.Email)
            .Map(dest => dest.Token, src => src.Token);
    }
}