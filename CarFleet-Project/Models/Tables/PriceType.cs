using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarFleet_Project.Models.Tables
{
    public class PriceType
    {
        public int priceId { get; set; }

        public string typeName { get; set; } = "";
    }
}
