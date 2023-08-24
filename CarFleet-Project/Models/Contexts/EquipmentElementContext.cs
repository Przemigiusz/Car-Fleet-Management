using CarFleet_Project.Models.Interfaces;
using CarFleet_Project.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CarFleet_Project.Models.Contexts
{
    public class EquipmentElementContext : DbContext, IEquipmentElementContext
    {
        public EquipmentElementContext(DbContextOptions<FilterContext> options) : base(options)
        {
        }
        public DbSet<EquipmentElement> EquipmentElements { get; set; }

        public IQueryable<EquipmentElement> GetAllEquipmentElements() {
            return EquipmentElements;
        }
    }
}
