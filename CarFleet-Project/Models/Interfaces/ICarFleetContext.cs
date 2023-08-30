using CarFleet_Project.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace CarFleet_Project.Models.Interfaces
{
    public interface ICarFleetContext
    {
        DbSet<Vehicle> Vehicles { get; set; }
        DbSet<EquipmentElement> EquipmentElements { get; set; }
        DbSet<PriceType> PriceTypes { get; set; }
        DbSet<SortingType> SortingTypes { get; set; }
        DbSet<CarbodyType> CarbodyTypes { get; set; }
        DbSet<FuelType> FuelTypes { get; set; }
        DbSet<TransmissionType> TransmissionTypes { get; set; }
        DbSet<VehicleImage> VehicleImages { get; set; }

        int SaveChanges();

        IQueryable<Vehicle> GetAllVehicles();
        IQueryable<EquipmentElement> GetAllEquipmentElements();
        IQueryable<PriceType> GetAllPriceTypes();
        IQueryable<SortingType> GetAllSortingTypes();
        IQueryable<CarbodyType> GetAllCarbodyTypes();
        IQueryable<FuelType> GetAllFuelTypes();
        IQueryable<TransmissionType> GetAllTransmissionTypes();
        IQueryable<VehicleImage> GetVehicleImages(int vehicleId);
    }
}