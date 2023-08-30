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

        //public IQueryable<VehicleImage> GetVehicleImages(int vehicleId)
        //{
        //    return VehicleImages.Where(vh => vh.);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //PRIMARY KEYS
            modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.vehicleId);

            modelBuilder.Entity<VehicleImage>()
                .HasKey(vi => vi.imageId);

            modelBuilder.Entity<TransmissionType>()
                .HasKey(tt => tt.typeId);

            modelBuilder.Entity<SortingType>()
                .HasKey(st => st.typeId);

            modelBuilder.Entity<PriceType>()
                .HasKey(pt => pt.priceId);

            modelBuilder.Entity<FuelType>()
                .HasKey(ft => ft.typeId);

            modelBuilder.Entity<EquipmentElement>()
                .HasKey(ee => ee.elementId);

            modelBuilder.Entity<CarbodyType>()
                .HasKey(ct => ct.typeId);

            //RELATIONSHIPS
            modelBuilder.Entity<Vehicle>() //def many-to-many relationship vehicle - equipment
                .HasMany(v => v.equipment)
                .WithMany(e => e.vehicles);

            modelBuilder.Entity<EquipmentElement>() //def many-to-many relationship equipment - vehicle
                .HasMany(e => e.vehicles)
                .WithMany(v => v.equipment);

            modelBuilder.Entity<Vehicle>() //def many-to-one relationship vehicle - vehicleImages
                .HasMany(v => v.vehicleImages)
                .WithOne(vi => vi.vehicle)
                .HasForeignKey(vi => vi.imageId);

            modelBuilder.Entity<VehicleImage>() //def one-to-many relationship vehicleImages - vehicle
               .HasOne(vi => vi.vehicle)
               .WithMany(v => v.vehicleImages)
               .HasForeignKey(v => v.vehicle);
            
        }
    }
}
