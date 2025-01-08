using Microsoft.AspNetCore.Mvc;

namespace P2_ASTRO.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{    
    [HttpGet]
    public IActionResult Welcome()
    {
        return Ok("Hello World");
    }
}