using CarFleet_Project.Models.Interfaces;
using CarFleet_Project.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CarFleet_Project.Models.Contexts
{
    public class CarFleetContext : DbContext, ICarFleetContext
    {
        public CarFleetContext(DbContextOptions<CarFleetContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<EquipmentElement> EquipmentElements { get; set; }
        public DbSet<PriceType> PriceTypes { get; set; }
        public DbSet<SortingType> SortingTypes { get; set; }
        public DbSet<CarbodyType> CarbodyTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<VehicleImage> VehicleImages { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public IQueryable<Vehicle> GetAllVehicles()
        {
            return Vehicles;
        }
        public IQueryable<EquipmentElement> GetAllEquipmentElements()
        {
            return EquipmentElements;
        }
        public IQueryable<PriceType> GetAllPriceTypes()
        {
            return PriceTypes;
        }
        public IQueryable<SortingType> GetAllSortingTypes()
        {
            return SortingTypes;
        }
        public IQueryable<CarbodyType> GetAllCarbodyTypes()
        {
            return CarbodyTypes;
        }
        public IQueryable<FuelType> GetAllFuelTypes()
        {
            return FuelTypes;
        }
        public IQueryable<TransmissionType> GetAllTransmissionTypes()
        {
            return TransmissionTypes;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasMany(e => e.equipment)
                .WithMany(e => e.vehicles);

            modelBuilder.Entity<EquipmentElement>()
                .HasMany(e => e.vehicles)
                .WithMany(e => e.equipment);
        }
    }
}
