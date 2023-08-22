using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarFleet_Project.Models;

namespace CarFleet_Project.Controllers;

[Route("api/get-vehicles")]
[ApiController]
public class ClientVehicleController : ControllerBase
{
    IVehicleContext _ctx;
    public ClientVehicleController(IVehicleContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var vehicle = _ctx.GetAll();
            return Ok(vehicle);
        }
        catch (Exception)
        {
            return BadRequest();
        }    
    }
}
