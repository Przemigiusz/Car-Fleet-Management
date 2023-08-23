using CarFleet_Project.Models.Interfaces;
using CarFleet_Project.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CarFleet_Project.Models.Contexts
{
    public class VehicleContext : DbContext, IVehicleContext
    {
        public VehicleContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<EquipmentElement> VehiclesEquipment { get; set; }

        public DbSet<PricePerDay> Filters { get; set; }
        public DbSet<SortingType> Sortings { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public IQueryable<Vehicle> GetAll()
        {
            return Vehicles;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasMany(e => e.equipment)
                .WithMany(e => e.vehicles);
        }
    }
}
