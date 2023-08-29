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
    IVehicleContext _ctx;
    public FilterController(IVehicleContext ctx)
    {
        _ctx = ctx;
    }

    [HttpPost]
    public async Task<IActionResult> Post()
    {
        var form = await Request.ReadFormAsync();
        var vehicleJson = form["vehicle"];
        Vehicle vehicle = JsonSerializer.Deserialize<Vehicle>(vehicleJson!)!;

        var file = form.Files.GetFile("file");
        var fileStream = file!.OpenReadStream();
        byte[] bytes = new byte[file.Length];
        fileStream.Read(bytes, 0, (int)file.Length);
        Image image = Image.Load(bytes);
        int width = 320;
        int height = 146;
        image.Mutate(x => x.Resize(width, height));


        using var output = new MemoryStream();
        image.Save(output, new JpegEncoder());

        byte[] compressedImage = output.ToArray();
        vehicle.vehicleImage = compressedImage;


        vehicle.equipment[vehicle.equipment.Count-1].vehicles.Add(vehicle);

        _ctx.Vehicles.Update(vehicle);
        try
        {
            var id = _ctx.SaveChanges();
            vehicle.vehicleId = id;
        }
        catch (Exception)
        {
            return BadRequest("Upsss, cos poszlo nie tak");
        }  
        return Ok(vehicle);
    }
}
