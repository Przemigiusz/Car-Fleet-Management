using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarFleet_Project.Models.Tables
{
    public class PriceType
    {
        [Key]
        public int priceId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string typeName { get; set; } = "";
    }
}
