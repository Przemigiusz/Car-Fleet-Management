using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarFleet_Project.Models;

namespace CarFleet_Project.Controllers;

[Route("api/vehicle")]
[ApiController]
public class AdminVehicleController : ControllerBase
{
    IVehicleContext _ctx;
    public AdminVehicleController(IVehicleContext ctx)
    {
        _ctx = ctx;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Vehicle vehicle)
    {
        _ctx.Vehicles.Add(vehicle);
        try
        {
            var id = _ctx.SaveChanges();
            vehicle.vehicleId = id;
        }
        catch (Exception)
        {
            return BadRequest();
        }  
        return Ok(vehicle);
    }
}
