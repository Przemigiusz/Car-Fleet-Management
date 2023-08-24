using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarFleet_Project.Models.Interfaces;
using CarFleet_Project.Models.Tables;

namespace CarFleet_Project.Controllers;

[Route("api/filters")]
[ApiController]
public class FiltersController : ControllerBase
{
    IFilterContext _ctx;
    public FiltersController(IFilterContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet("carbody-types")]
    public IActionResult GetAllCarbodyTypes()
    {
        try
        {
            var carbodyTypes = _ctx.GetAllCarbodyTypes();
            return Ok(carbodyTypes);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("sorting-types")]
    public IActionResult GetAllSortingTypes()
    {
        try
        {
            var sortingTypes = _ctx.GetAllSortingTypes();
            return Ok(sortingTypes);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("prices-per-day")]
    public IActionResult GetAllPricesPerDay()
    {
        try
        {
            var pricesPerDay = _ctx.GetAllPriceTypes();
            return Ok(pricesPerDay);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("fuel-types")]
    public IActionResult GetAllFuelTypes()
    {
        try
        { 
            var fuelTypes = _ctx.GetAllFuelTypes();
            return Ok(fuelTypes);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("transmission-types")]
    public IActionResult GetAllTransmissionsTypes()
    {
        try
        {
            var transmissionTypes = _ctx.GetAllTransmissionTypes();
            return Ok(transmissionTypes);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
