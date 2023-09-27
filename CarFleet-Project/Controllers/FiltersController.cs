using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarFleet_Project.Models.Interfaces;
using CarFleet_Project.Models.Tables;

namespace CarFleet_Project.Controllers;

[Route("api/filters")]
[ApiController]
public class FiltersController : ControllerBase
{
    ICarFleetContext _ctx;
    public FiltersController(ICarFleetContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet("get-carbodies")]
    public IActionResult GetAllCarbodyTypes()
    {
        try
        {
            var carbodyTypes = _ctx.GetAllCarbodies();
            return Ok(carbodyTypes);
        }
        catch (Exception)
        {
            return BadRequest("There is a problem with getting carbody types");
        }
    }

    [HttpGet("get-sorting-types")]
    public IActionResult GetAllSortingTypes()
    {
        try
        {
            var sortingTypes = _ctx.GetAllSortingTypes();
            return Ok(sortingTypes);
        }
        catch (Exception)
        {
            return BadRequest("There is a problem with getting sorting types");
        }
    }

    [HttpGet("get-price-ranges")]
    public IActionResult GetAllPricesPerDay()
    {
        try
        {
            var priceRanges = _ctx.GetAllPriceRanges();
            return Ok(priceRanges);
        }
        catch (Exception)
        {
            return BadRequest("There is a problem with getting price ranges");
        }
    }

    [HttpGet("get-fuels")]
    public IActionResult GetAllFuelTypes()
    {
        try
        { 
            var fuelTypes = _ctx.GetAllFuels();
            return Ok(fuelTypes);
        }
        catch (Exception)
        {
            return BadRequest("There is a problem with getting fuel types");
        }
    }

    [HttpGet("get-transmission-types")]
    public IActionResult GetAllTransmissionTypes()
    {
        try
        {
            var transmissionTypes = _ctx.GetAllTransmissionTypes();
            return Ok(transmissionTypes);
        }
        catch (Exception)
        {
            return BadRequest("There is a problem with getting transmission types");
        }
    }

    [HttpGet("get-models")]
    public IActionResult GetModels()
    {
        try
        {
            var models = _ctx.GetAllModels();
            return Ok(models);
        }
        catch (Exception)
        {
            return BadRequest("There is a problem with getting models connected with that brandId");
        }
    }

    [HttpGet("get-brands")]
    public IActionResult GetAllBrands()
    {
        try
        {
            var brands = _ctx.GetAllBrands();
            return Ok(brands);
        }
        catch (Exception)
        {
            return BadRequest("There is a problem with getting brands");
        }
    }

    [HttpGet("get-years")]
    public IActionResult GetAllYears()
    {
        try
        {
            var years = _ctx.GetAllYears();
            return Ok(years);
        }
        catch (Exception)
        {
            return BadRequest("There is a problem with getting years of production");
        }
    }
}
