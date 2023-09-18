namespace CarFleet_Project.Models.Tables
{
    public class Model
    {
        public int modelId { get; set; }
        public string modelName { get; set; } = "";
        public int brandId { get; set; }
        public virtual Brand brand { get; set; } = null!;
        public virtual List<Vehicle> vehicles { get; set; } = null!;
    }
}
