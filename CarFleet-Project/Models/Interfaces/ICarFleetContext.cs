using CarFleet_Project.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace CarFleet_Project.Models.Interfaces
{
    public interface ICarFleetContext
    {
        DbSet<Vehicle> Vehicles { get; set; }
        DbSet<EquipmentElement> EquipmentElements { get; set; }
        DbSet<PriceRange> PriceRanges { get; set; }
        DbSet<SortingType> SortingTypes { get; set; }
        DbSet<Carbody> Carbodies { get; set; }
        DbSet<Fuel> Fuels { get; set; }
        DbSet<TransmissionType> TransmissionTypes { get; set; }
        DbSet<VehicleImage> VehicleImages { get; set; }
        DbSet<Model> Models { get; set; }
        DbSet<Brand> Brands { get; set; }

        int SaveChanges();

        IQueryable<Vehicle> GetAllVehicles();
        IQueryable<EquipmentElement> GetAllEquipmentElements();
        IQueryable<PriceRange> GetAllPriceRanges();
        IQueryable<SortingType> GetAllSortingTypes();
        IQueryable<Carbody> GetAllCarbodies();
        IQueryable<Fuel> GetAllFuels();
        IQueryable<TransmissionType> GetAllTransmissionTypes();
        IQueryable<VehicleImage> GetVehicleImages(int vehicleId);
        IQueryable<Model> GetModels(int brandId);
        IQueryable<Brand> GetAllBrands();
    }
}