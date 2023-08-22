using Microsoft.EntityFrameworkCore;

namespace CarFleet_Project.Models
{
    public class VehicleContext : DbContext, IVehicleContext
    {
        public VehicleContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
