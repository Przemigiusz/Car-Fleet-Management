using CarFleet_Project.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace CarFleet_Project.Models.Interfaces
{
    public interface IVehicleContext
    {
        DbSet<Vehicle> Vehicles { get; set; }
        DbSet<EquipmentElement> VehiclesEquipment { get; set; }
        DbSet<PricePerDay> Filters { get; set; }
        DbSet<SortingType> Sortings { get; set; }

        int SaveChanges();

        IQueryable<Vehicle> GetAll();
    }
}