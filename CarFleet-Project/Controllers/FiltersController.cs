﻿using Microsoft.AspNetCore.Http;
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
            var pricesPerDay = _ctx.GetAllPriceRanges();
            return Ok(pricesPerDay);
        }
        catch (Exception)
        {
            return BadRequest("There is a problem with getting price types");
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
    public IActionResult GetAllTransmissionsTypes()
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
}
