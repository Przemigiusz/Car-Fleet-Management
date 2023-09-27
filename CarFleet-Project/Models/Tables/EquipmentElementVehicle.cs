using Azure;
using Microsoft.Extensions.Hosting;

namespace CarFleet_Project.Models.Tables
{
    public class EquipmentElementVehicle
    {
        public int vehicleId { get; set; }
        public int elementId { get; set; }
        public Vehicle vehicle { get; set; } = null!;
        public EquipmentElement equipmentElement { get; set; } = null!;
    }
}
