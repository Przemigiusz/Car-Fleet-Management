using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarFleet_Project.Models.Interfaces;
using CarFleet_Project.Models.Tables;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;
using System.IO;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace CarFleet_Project.Controllers;

[Route("api/vehicle")]
[ApiController]
public class FilterController : ControllerBase
{
    ICarFleetContext _ctx;
    public FilterController(ICarFleetContext ctx)
    {
        _ctx = ctx;
    }

    //[HttpPost("post-vehicle")]
    //public async Task<IActionResult> PostVehicle()
    //{
    //    var form = await Request.ReadFormAsync();
    //    var vehicleJson = form["vehicle"];
    //    Vehicle vehicle = JsonSerializer.Deserialize<Vehicle>(vehicleJson!)!;

    //    var file = form.Files.GetFile("file");
    //    var fileStream = file!.OpenReadStream();
    //    byte[] bytes = new byte[file.Length];
    //    fileStream.Read(bytes, 0, (int)file.Length);
    //    Image image = Image.Load(bytes);
    //    int width = 320;
    //    int height = 146;
    //    image.Mutate(x => x.Resize(width, height));


    //    using var output = new MemoryStream();
    //    image.Save(output, new JpegEncoder());

    //    byte[] compressedImage = output.ToArray();
    //    vehicle.vehicleImages.Add(compressedImage);

    //    _ctx.Vehicles.Update(vehicle);
    //    try
    //    {
    //        var id = _ctx.SaveChanges();
    //        vehicle.vehicleId = id;
    //    }
    //    catch (Exception)
    //    {
    //        return BadRequest("There is a problem with updating db with a new car");
    //    }
    //    return Ok(vehicle);
    //}

    [HttpPost("post-image")]
    public IActionResult PostImage([FromBody] VehicleImage vehicleImage)
    {
        try
        {
            var id = _ctx.SaveChanges();
            vehicleImage.imageId = id;
        }
        catch (Exception)
        {
            return BadRequest("There is a problem with updating db with a new image");
        }
        return Ok(vehicleImage);
    }

    [HttpGet("get-vehicles")] 
    public IActionResult GetVehicles()
    {
        try
        {
            var vehicles = _ctx.GetAllVehicles().Include(c => c.equipment).ToList();

            return Ok(vehicles);
        }
        catch (Exception)
        {
            return BadRequest("There is a problem with getting car info from db");
        }
    }
}
