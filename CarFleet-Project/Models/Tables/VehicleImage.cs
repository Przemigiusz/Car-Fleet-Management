namespace CarFleet_Project.Models.Tables
{
    public class VehicleImage
    {
        public int imageId { get; set; }
        public string imageType { get; set; } = "";
        public string imageName { get; set; } = "";
        public int vehicleId { get; set; }
        public virtual Vehicle vehicle { get; set; } = null!;
        public byte[] image { get; set; } = null!;


    }
}
