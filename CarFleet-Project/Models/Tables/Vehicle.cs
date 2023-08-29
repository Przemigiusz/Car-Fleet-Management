
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleet_Project.Models.Tables
{
    public class Vehicle
    {
        [Key]
        public int vehicleId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string brand { get; set; } = "";

        [Column(TypeName = "nvarchar(20)")]
        public string model { get; set; } = "";

        [Column(TypeName = "nvarchar(4)")]
        public string yearOfProduction { get; set; } = "";

        [Column(TypeName = "nvarchar(20)")]
        public string mileage { get; set; } = "";

        [Column(TypeName = "nvarchar(20)")]
        public string fuelType { get; set; } = "";

        [Column(TypeName = "nvarchar(2)")]
        public string doorsAmount { get; set; } = "";

        [Column(TypeName = "nvarchar(20)")]
        public string carBodyType { get; set; } = "";

        public byte[] vehicleImage { get; set; } = null!;

        public List<EquipmentElement> equipment { get; set; } = new();
    }
}
