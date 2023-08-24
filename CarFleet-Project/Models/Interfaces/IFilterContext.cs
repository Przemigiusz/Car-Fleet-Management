using CarFleet_Project.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace CarFleet_Project.Models.Interfaces
{
    public interface IFilterContext
    {
        DbSet<PriceType> PriceTypes { get; set; }
        DbSet<SortingType> SortingTypes { get; set; }
        DbSet<CarbodyType> CarbodyTypes { get; set; }
        DbSet<FuelType> FuelTypes { get; set; }
        DbSet<TransmissionType> TransmissionTypes { get; set; }

        IQueryable<PriceType> GetAllPriceTypes();
        IQueryable<SortingType> GetAllSortingTypes();
        IQueryable<CarbodyType> GetAllCarbodyTypes();
        IQueryable<FuelType> GetAllFuelTypes();
        IQueryable<TransmissionType> GetAllTransmissionTypes();
    }
}