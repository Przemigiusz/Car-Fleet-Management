using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarFleet_Project.Models.Tables
{
    public class CarbodyType
    {
        [Key]
        public int typeId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string typeName { get; set; } = "";
    }
}
