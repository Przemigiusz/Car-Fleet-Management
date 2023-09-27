namespace CarFleet_Project.Models.Tables
{
    public class TransmissionType
    {
        public int typeId { get; set; }
        public string typeName { get; set; } = "";
        public virtual List<Vehicle> vehicles { get; } = new();
    }
}
