namespace CarFleet_Project.Models.Tables
{
    public class Carbody
    {
        public int carbodyId { get; set; }
        public string carbodyName { get; set; } = "";
        public virtual List<Vehicle> vehicles { get; set; } = new();
    }
}
