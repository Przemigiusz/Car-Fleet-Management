using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarFleet_Project.Models.Tables
{
    public class PriceRange
    {
        public int priceRangeId { get; set; }
        private string priceRangeName { get; set; } = "";
    }
}
