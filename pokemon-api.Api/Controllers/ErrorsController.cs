using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace pokemon_api.Api.Controllers;

public class ErrorsController: ControllerBase
{
    [Route("/error")]
    [HttpGet] 
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Problem();
    }
}