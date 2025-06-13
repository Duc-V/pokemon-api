using Microsoft.AspNetCore.Mvc;

namespace pokemon_api.Api.Controllers;

[Route("dinners")]
public class DinnersController: ApiController
{   
    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}