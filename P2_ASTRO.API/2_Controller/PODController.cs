using Microsoft.AspNetCore.Mvc;
using P2_ASTRO.API.DTO;
using P2_ASTRO.API.Service;

namespace P2_ASTRO.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class PODController : ControllerBase
{
    private readonly IPODService _podService;

    public PODController(IPODService podService)
    {
        _podService = podService;
    }

    [HttpGet]
    public IActionResult GetAllPODs()
    {
        var podList = _podService.GetAllPODs();
        if (podList == null || !podList.Any())
        {
            return NotFound("No PODs found.");
        }
        return Ok(podList);
    }

    [HttpGet("{podId}")]
    public IActionResult GetPODById(int podId)
    {
        try
        {
            var pod = _podService.GetPODbyId(podId);
            if (pod == null)
            {
                return NotFound("No POD found for podId = " + podId);
            }
            return Ok(pod);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("date/{date}")]
    public IActionResult GetPODByDate(DateOnly date)
    {
        try
        {
            var pod = _podService.GetPODbyDate(date);
            if (pod == null)
            {
                return NotFound("No POD found for date = " + date);
            }
            return Ok(pod);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateNewPOD([FromBody] PODInDTO newPODInDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var pod = _podService.CreateNewPOD(newPODInDTO);
        if (pod == null)
        {
            return BadRequest("Invalid input for creating a new POD.");
        }
        return CreatedAtAction(nameof(GetPODById), new { podId = pod.PODId }, pod);
    }
}
