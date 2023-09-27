namespace CarFleet_Project.Models.Tables
{
    public class EquipmentElement
    {
        public int elementId { get; set; }
        public string elementName { get; set; } = "";
        public virtual List<Vehicle> vehicles { get; set; } = new();
    }
}
