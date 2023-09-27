using CarFleet_Project.Models.Interfaces;
using CarFleet_Project.Models.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<YearOfProduction> Years { get; set; }

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
        public IQueryable<Model> GetAllModels() {
            return Models;
        }
        public IQueryable<Brand> GetAllBrands() {
            return Brands;
        }
        public IQueryable<YearOfProduction> GetAllYears()
        {
            return Years;
        }

        public ValueTask<Brand?> GetSpecificBrand(int brandId)
        {
            return Brands.FindAsync(brandId);
        }

        public ValueTask<Model?> GetSpecificModel(int modelId)
        {
            return Models.FindAsync(modelId);
        }
        public ValueTask<Carbody?> GetSpecificCarbody(int carbodyId)
        {
            return Carbodies.FindAsync(carbodyId);
        }
        public ValueTask<YearOfProduction?> GetSpecificYear(int yearId)
        {
            return Years.FindAsync(yearId);
        }
        public ValueTask<TransmissionType?> GetSpecificTransmissionType(int transmissionTypeId)
        {
            return TransmissionTypes.FindAsync(transmissionTypeId);
        }
        public async ValueTask<List<Fuel>> GetSpecificFuels(List<int> fuelIds)
        {
            return await Fuels.Where(fuel => fuelIds.Contains(fuel.fuelId)).ToListAsync();
        }
        public async ValueTask<List<EquipmentElement>> GetSpecificEquipment(List<int> equipmentIds)
        {
            return await EquipmentElements.Where(eq => equipmentIds.Contains(eq.elementId)).ToListAsync();
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

            modelBuilder.Entity<Model>()
                .HasKey(m => m.modelId);

            modelBuilder.Entity<YearOfProduction>()
                .HasKey(y => y.yearId);

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
                .HasForeignKey(vi => vi.vehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>() //def many-to-one relationship vehicle - carbody
                .HasOne(v => v.carbody)
                .WithMany(c => c.vehicles)
                .HasForeignKey(v => v.carbodyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>() //def many-to-one relationship vehicle - transmissionType
                .HasOne(v => v.transmissionType)
                .WithMany(tt => tt.vehicles)
                .HasForeignKey(v => v.transmissionTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>() //def many-to-one relationship vehicle - model
                .HasOne(v => v.model)
                .WithMany(m => m.vehicles)
                .HasForeignKey(v => v.modelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>() //def many-to-one relationship vehicle - brand
                .HasOne(v => v.brand)
                .WithMany(b => b.vehicles)
                .HasForeignKey(v => v.brandId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Brand>() //def one-to-many relationship brand - model
                .HasMany(b => b.models)
                .WithOne(m => m.brand)
                .HasForeignKey(m => m.brandId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>() //def one-to-many relationship vehicle - yearOfProduction
                .HasOne(v => v.yearOfProduction)
                .WithMany(y => y.vehicles)
                .HasForeignKey(v => v.yearId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
