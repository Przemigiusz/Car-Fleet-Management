using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarFleet_Project.Models.Tables
{
    public class FuelType
    {
        public int typeId { get; set; }

        public string typeName { get; set; } = "";
    }
}
