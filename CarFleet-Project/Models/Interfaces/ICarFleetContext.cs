using CarFleet_Project.Models.Tables;
using Microsoft.EntityFrameworkCore;
using System;

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
        DbSet<YearOfProduction> Years { get; set; }

        int SaveChanges();

        IQueryable<Vehicle> GetAllVehicles(); // At every single shot there will be loaded next X vehicles, but there is limited size of buffor(for ex - 20 cars) 
        IQueryable<EquipmentElement> GetAllEquipmentElements(); // All of them will always be loaded here
        IQueryable<PriceRange> GetAllPriceRanges(); // All of them will always be loaded here
        IQueryable<SortingType> GetAllSortingTypes(); // All of them will always be loaded here
        IQueryable<Carbody> GetAllCarbodies(); // All of them will always be loaded here
        IQueryable<Fuel> GetAllFuels(); // All of them will always be loaded here
        IQueryable<TransmissionType> GetAllTransmissionTypes(); // All of them will always be loaded here
        IQueryable<VehicleImage> GetVehicleImages(int vehicleId); // If we have 20 cars loaded, there will be that many main photos,
                                                                  // if client decides to check out specific car, photos of that car will be loaded 
        IQueryable<Model> GetModels(int brandId); // They will be loaded when the brand is choosen
        IQueryable<Brand> GetAllBrands(); // All of them will always be loaded here
        IQueryable<YearOfProduction> GetAllYears(); // All of them will always be loaded here
    }
}