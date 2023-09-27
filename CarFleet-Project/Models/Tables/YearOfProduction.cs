namespace CarFleet_Project.Models.Tables
{
    public class YearOfProduction
    {
        public int yearId { get; set; }
        public string year { get; set; } = "";
        public virtual List<Vehicle> vehicles { get; } = new();
    }
}
