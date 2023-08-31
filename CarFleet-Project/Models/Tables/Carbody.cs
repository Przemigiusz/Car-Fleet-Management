using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarFleet_Project.Models.Tables
{
    public class Carbody
    {
        public int carbodyId { get; set; }
        private string carbodyName { get; set; } = "";
        public virtual List<Vehicle> vehicles { get; set; } = null!;
    }
}
