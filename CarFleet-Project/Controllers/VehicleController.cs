using Microsoft.AspNetCore.Mvc;
using CarFleet_Project.Models.Interfaces;
using CarFleet_Project.Models.Tables;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using System.Data;
using CarFleet_Project.Services;

namespace CarFleet_Project.Controllers;

[Route("api/vehicle")]
[ApiController]
public class FilterController : ControllerBase
{
    ICarFleetContext _ctx;
    ToDbService toDbService;

    private int pageSize = 10;
    private int vehicleId = 0;
    public FilterController(ICarFleetContext ctx, ToDbService toDbService)
    {
        this._ctx = ctx;
        this.toDbService = toDbService;
    }

    [HttpPost("post-vehicle")]
    public async Task<IActionResult> PostVehicle()
    {
        try
        {
            string requestBody;
            using (StreamReader reader = new StreamReader(Request.Body)) {
                requestBody = await reader.ReadToEndAsync();
            }
            Vehicle newVehicle = await this.toDbService.VehicleConversion(requestBody);
            _ctx.Vehicles.Update(newVehicle);
            _ctx.SaveChanges();
            return Ok(newVehicle.vehicleId);
        }
        catch (Exception ex)
        {
            return BadRequest("There is a problem with adding a new vehicle to the database" + ex);
        }
    }


    [HttpPost("post-image")]
    public IActionResult PostImage([FromForm] List<IFormFile> vehicleImages, [FromForm] int vehicleId)
    {
        try
        {
            if (vehicleImages != null && vehicleImages.Any()) {
                foreach (var image in vehicleImages) {
                    if (image.Length > 0) {
                        var vehicleImage = new VehicleImage();
                        vehicleImage.imageName = image.Name;
                        vehicleImage.imageType = image.ContentType;
                        var contentTypeParts = image.ContentType.Split("/");
                        if (contentTypeParts.Length == 2)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                image.CopyTo(memoryStream);
                                var processedImg = Image.Load(memoryStream.ToArray());
                                var newWidth = 284;
                                var newHeight = 208;
                                processedImg.Mutate(x => x.Resize(new ResizeOptions
                                {
                                    Size = new Size(newWidth, newHeight),
                                    Mode = ResizeMode.Max // Dostosuj tryb skalowania do Twoich potrzeb
                                }));

                                IImageEncoder encoder;
                                switch (vehicleImage.imageType)
                                {
                                    case "jpg":
                                    case "jpeg":
                                        encoder = new JpegEncoder();
                                        break;
                                    case "png":
                                        encoder = new PngEncoder();
                                        break;
                                    default:
                                        encoder = new JpegEncoder();
                                        break;
                                }
                                memoryStream.Seek(0, SeekOrigin.Begin);
                                processedImg.Save(memoryStream, encoder);
                                vehicleImage.image = memoryStream.ToArray();
                            }
                            vehicleImage.vehicleId = vehicleId;
                            _ctx.VehicleImages.Update(vehicleImage);
                            _ctx.SaveChanges();
                        }
                        else {
                            Console.WriteLine("Nieobsługiwany podtyp!");
                        }

                        
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return BadRequest("There is a problem with adding new images to the database" + ex) ;
        }
        return Ok("Vehicle images has been added successfully");
    }

    [HttpGet("get-vehicles-images")]
    public IActionResult GetVehiclesImages()
    {
        try
        {
            var vehicles = _ctx.GetAllVehicles().Include(c => c.equipment).ToList();

            return Ok(vehicles);
        }
        catch (Exception ex)
        {
            return BadRequest("There is a problem with getting images info from db" + ex);
        }
    }

    [HttpGet("get-vehicles")] 
    public IActionResult GetVehicles()
    {
        try
        {
            var vehicles = _ctx.GetAllVehicles()
                //.Include(v => v.equipment)
                .OrderBy(v => v.vehicleId)
                .Where(v => v.vehicleId > vehicleId)
                .Take(pageSize)
                .ToList();

            return Ok(vehicles);
        }
        catch (Exception ex)
        {
            return BadRequest("There is a problem with getting car info from db" + ex);
        }
    }
}
