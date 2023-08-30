
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleet_Project.Models.Tables
{
    public class VehicleImage
    {
        [Key]
        public int imageId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string imageType { get; set; } = "";

        [Column(TypeName = "nvarchar(50)")]
        public string imageName { get; set; } = "";

        public byte[] vehicleImage { get; set; } = null!;
    }
}
