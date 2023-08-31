
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleet_Project.Models.Tables
{
    public class VehicleImage
    {
        public int imageId { get; set; }
        private string imageType { get; set; } = "";
        private string imageName { get; set; } = "";
        private int vehicleId { get; set; }
        public virtual Vehicle vehicle { get; set; } = null!;
        private byte[] image { get; set; } = null!;


    }
}
