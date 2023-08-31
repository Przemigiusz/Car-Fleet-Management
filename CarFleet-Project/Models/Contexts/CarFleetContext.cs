using CarFleet_Project.Models.Interfaces;
using CarFleet_Project.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace CarFleet_Project.Models.Contexts
{
    public class CarFleetContext : DbContext, ICarFleetContext
    {
        public CarFleetContext(DbContextOptions<CarFleetContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<EquipmentElement> EquipmentElements { get; set; }
        public DbSet<PriceRange> PriceRanges { get; set; }
        public DbSet<SortingType> SortingTypes { get; set; }
        public DbSet<Carbody> Carbodies { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<VehicleImage> VehicleImages { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Brand> Brands { get; set; }

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
        public IQueryable<PriceRange> GetAllPriceRanges()
        {
            return PriceRanges;
        }
        public IQueryable<SortingType> GetAllSortingTypes()
        {
            return SortingTypes;
        }
        public IQueryable<Carbody> GetAllCarbodies()
        {
            return Carbodies;
        }
        public IQueryable<Fuel> GetAllFuels()
        {
            return Fuels;
        }
        public IQueryable<TransmissionType> GetAllTransmissionTypes()
        {
            return TransmissionTypes;
        }
        public IQueryable<VehicleImage> GetVehicleImages(int vehicleId) {
            return VehicleImages.Where(vi => vi.vehicle.vehicleId == vehicleId);
        }
        public IQueryable<Model> GetModels(int brandId) {
            return Models.Where(m => m.brand.brandId == brandId);
        }
        public IQueryable<Brand> GetAllBrands() {
            return Brands;
        }

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

            modelBuilder.Entity<PriceRange>()
                .HasKey(pr => pr.priceRangeId);

            modelBuilder.Entity<Fuel>()
                .HasKey(f => f.fuelId);

            modelBuilder.Entity<EquipmentElement>()
                .HasKey(ee => ee.elementId);

            modelBuilder.Entity<Carbody>()
                .HasKey(c => c.carbodyId);

            //RELATIONSHIPS
            modelBuilder.Entity<Vehicle>() //def many-to-many relationship vehicle - equipment
                .HasMany(v => v.equipment)
                .WithMany(ee => ee.vehicles);

            modelBuilder.Entity<Vehicle>() //def many-to-many relationship vehicle - fuel
                .HasMany(v => v.fuels)
                .WithMany(f => f.vehicles);

            modelBuilder.Entity<Vehicle>() //def many-to-one relationship vehicle - vehicleImages
                .HasMany(v => v.vehicleImages)
                .WithOne(vi => vi.vehicle)
                .HasForeignKey(vi => vi.imageId);

            modelBuilder.Entity<Vehicle>() //def many-to-one relationship vehicle - carbody
                .HasOne(v => v.carbody)
                .WithMany(c => c.vehicles)
                .HasForeignKey(v => v.carbodyId);

            modelBuilder.Entity<Vehicle>() //def many-to-one relationship vehicle - transmissionType
                .HasOne(v => v.transmissionType)
                .WithMany(tt => tt.vehicles)
                .HasForeignKey(v => v.transmissionTypeId);

            modelBuilder.Entity<Vehicle>() //def many-to-one relationship vehicle - model
                .HasOne(v => v.model)
                .WithMany(m => m.vehicles)
                .HasForeignKey(v => v.modelId);

            modelBuilder.Entity<Vehicle>() //def many-to-one relationship vehicle - brand
                .HasOne(v => v.brand)
                .WithMany(b => b.vehicles)
                .HasForeignKey(v => v.brandId);

        }
    }
}
