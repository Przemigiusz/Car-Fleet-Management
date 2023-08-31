namespace CarFleet_Project.Models.Tables
{
    public class Model
    {
        private int modelId { get; set; }
        private string modelName { get; set; } = "";
        private int brandId { get; set; }
        public virtual Brand brand { get; set; } = null!;
        public virtual List<Vehicle> vehicles { get; set; } = null!;
    }
}
