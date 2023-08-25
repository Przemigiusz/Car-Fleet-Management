using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarFleet_Project.Models.Interfaces;
using CarFleet_Project.Models.Tables;

namespace CarFleet_Project.Controllers;

[Route("api/equipment")]
[ApiController]
public class EquipmentElementsController : ControllerBase
{
    IVehicleContext _ctx;
    public EquipmentElementsController(IVehicleContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet("equipment-elements")]
    public IActionResult GetAllEquipmentElements()
    {
        try
        {
            var equipmentElements = _ctx.GetAllEquipmentElements();
            return Ok(equipmentElements);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

}

