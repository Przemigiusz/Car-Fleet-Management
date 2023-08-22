using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarFleet_Project.Controllers;

[Route("api/Vehicle")]
[ApiController]
public class VehicleController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(DateTime.Now);
    }
}
