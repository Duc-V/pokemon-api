using ErrorOr;
using FluentValidation;
using MediatR;
using pokemon_api.Application.Authentication.Commands.Register;
using pokemon_api.Application.Authentication.Common;

namespace pokemon_api.Application.Common.Behaviour;

// IRequest is MediatR request
// IResponse is type ErrorOr
public class ValidationBehaviour<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehaviour(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }
    
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
         CancellationToken cancellationToken)
    {
        // if there is no validtor move the request to the handler
        if (_validator is null)
        {
            return await next();
        }
        
        var validationResult = await _validator.ValidateAsync(request);

        if (validationResult.IsValid)
        {
            return await next();
        }
        
        var errrors = validationResult.Errors
            .ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage));
        
        return (dynamic)errrors;
    }
}