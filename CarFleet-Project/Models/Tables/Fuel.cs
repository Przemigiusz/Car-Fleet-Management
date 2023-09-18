using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarFleet_Project.Models.Tables
{
    public class Fuel
    {
        public int fuelId { get; set; }
        public string fuelName { get; set; } = "";
        public virtual List<Vehicle> vehicles { get; set; } = null!;
    }
}
