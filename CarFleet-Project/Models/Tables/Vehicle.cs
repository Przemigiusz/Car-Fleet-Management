using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleet_Project.Models.Tables
{
    public class Vehicle
    {
        public int vehicleId { get; set; }
        public int brandId { get; set; }
        public virtual Brand brand { get; set; } = null!;
        public int modelId { get; set; }
        public virtual Model model { get; set; } = null!;
        public virtual List<Fuel> fuels { get; set; } = new();
        public int carbodyId { get; set; }
        public virtual Carbody carbody { get; set; } = null!;
        public int yearId { get; set; }
        public virtual YearOfProduction yearOfProduction { get; set; } = null!;
        public int transmissionTypeId { get; set; }
        public virtual TransmissionType transmissionType { get; set; } = null!;
        public virtual List<VehicleImage> vehicleImages { get; set; } = new();
        public virtual List<EquipmentElement> equipment { get; set; } = new();
        public string mileage { get; set; } = "";
    }
}
