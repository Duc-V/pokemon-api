using Microsoft.AspNetCore.Mvc;
using pokemon_api.Application.Menus;

namespace pokemon_api.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenuController: ApiController
{
    [HttpPost]
    public IActionResult CreateMenu(CreateMenuRequest request, string hostId)
    {
        return Ok(request);
    }
}