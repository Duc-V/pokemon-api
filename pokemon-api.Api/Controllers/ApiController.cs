﻿using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using pokemon_api.Api.Common.Http;

namespace pokemon_api.Api.Controllers;

// [Authorize]
public class ApiController: ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count == 0)
        {
            return Problem();
        }
        
        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            ValidationProblem(errors);
        }
        
        // Temporarily stores the list of errors in the HttpContext for the duration of the current HTTP request only.
        HttpContext.Items[HttpContextItemKey.Errors] = errors;
        var firstError = errors[0];

        return Problem(firstError);        
    }

    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        };
        return Problem(statusCode: statusCode, detail: error.Description); 
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();

        foreach (var error in errors)
        {
            modelStateDictionary.AddModelError(
                error.Code, 
                error.Description);
        }

        return ValidationProblem(modelStateDictionary);
    }
}