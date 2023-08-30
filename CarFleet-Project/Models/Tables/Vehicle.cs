
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleet_Project.Models.Tables
{
    public class Vehicle
    {
        public int vehicleId { get; set; }

        public string brand { get; set; } = "";

        public string model { get; set; } = "";

        public string yearOfProduction { get; set; } = "";

        public string mileage { get; set; } = "";

        public string fuelType { get; set; } = "";

        public string doorsAmount { get; set; } = "";

        public string carBodyType { get; set; } = "";

        public VehicleImage[] vehicleImages { get; set; } = null!;

        public List<EquipmentElement> equipment { get; set; } = new();
    }
}
