using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarFleet_Project.Models.Tables
{
    public class TransmissionType
    {
        public int typeId { get; set; }
        public string typeName { get; set; } = "";
        public int vehicleId;
        public virtual List<Vehicle> vehicles { get; set; } = null!;
    }
}
