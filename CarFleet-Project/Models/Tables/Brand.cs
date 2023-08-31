namespace CarFleet_Project.Models.Tables
{
    public class Brand
    {
        public int brandId { get; set; } = 0;
        private string brandName { get; set; } = "";
        public virtual List<Vehicle> vehicles { get; set; } = new();
        public virtual List<Model> models { get; set; } = new();
    }
}
