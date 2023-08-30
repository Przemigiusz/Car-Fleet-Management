
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleet_Project.Models.Tables
{
    public class VehicleImage
    {
        public int imageId { get; set; }

        public string imageType { get; set; } = "";

        public string imageName { get; set; } = "";

        public Vehicle vehicle { get; set; } = null!;

        public byte[] vehicleImage { get; set; } = null!;


    }
}
