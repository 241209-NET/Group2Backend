using Microsoft.AspNetCore.Mvc;

namespace P2_ASTRO.API.Controller;

[Route("/")]
[ApiController]
public class HomeController : ControllerBase
{    
    [HttpGet]
    public IActionResult Welcome()
    {
        return Ok("Hello World");
    }
}