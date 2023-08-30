using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarFleet_Project.Models.Interfaces;
using CarFleet_Project.Models.Tables;

namespace CarFleet_Project.Controllers;

[Route("api/equipment")]
[ApiController]
public class EquipmentController : ControllerBase
{
    ICarFleetContext _ctx;
    public EquipmentController(ICarFleetContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet("get-equipment-elements")]
    public IActionResult GetAllEquipmentElements()
    {
        try
        {
            var equipmentElements = _ctx.GetAllEquipmentElements();
            return Ok(equipmentElements);
        }
        catch (Exception)
        {
            return BadRequest("There is a problem with getting equipment elements");
        }
    }

}

