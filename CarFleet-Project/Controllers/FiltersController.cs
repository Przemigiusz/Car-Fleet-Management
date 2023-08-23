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

    [HttpGet("/carbody-types")]
    public IActionResult GetAllCarbodyTypes()
    {
        try
        {
            var vehicle = _ctx.GetAllCarbodyTypes();
            return Ok(vehicle);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("/sorting-types")]
    public IActionResult GetAllSortingTypes()
    {
        try
        {
            var vehicle = _ctx.GetAllSortingTypes();
            return Ok(vehicle);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("/prices-per-day")]
    public IActionResult GetAllPricesPerDay()
    {
        try
        {
            var vehicle = _ctx.GetAllPricesPerDay();
            return Ok(vehicle);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("/fuel-types")]
    public IActionResult GetAllFuelTypes()
    {
        try
        {
            var vehicle = _ctx.GetAllFuelTypes();
            return Ok(vehicle);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
