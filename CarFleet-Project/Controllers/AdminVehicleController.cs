using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarFleet_Project.Models.Interfaces;
using CarFleet_Project.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace CarFleet_Project.Controllers;

[Route("api/vehicle")]
[ApiController]
public class FilterController : ControllerBase
{
    IVehicleContext _ctx;
    public FilterController(IVehicleContext ctx)
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
        catch (DbUpdateException ex)
        {
            throw ex;
        }
        catch (Exception)
        {
            return BadRequest("Upsss, cos poszlo nie tak");
        }  
        return Ok(vehicle);
    }
}
