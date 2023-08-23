using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarFleet_Project.Models.Tables
{
    public class EquipmentElement
    {
        [Key]
        public int elementId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string elementName { get; set; } = "";

        public List<Vehicle> vehicles { get; set; } = new();
    }
}
