using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using pokemon_api.Api.Common.Http;

namespace pokemon_api.Api.Controllers;

public class ApiController: ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        HttpContext.Items[HttpContextItemKey.Errors] = errors;
        var firstError = errors[0];

        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        };
        
        return Problem(statusCode: statusCode, detail: firstError.Description); 
    }
}