using CarFleet_Project.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace CarFleet_Project.Models.Interfaces
{
    public interface IFilterContext
    {
        DbSet<PricePerDay> PricesPerDay { get; set; }
        DbSet<SortingType> SortingTypes { get; set; }
        DbSet<CarbodyType> CarbodyTypes { get; set; }
        DbSet<FuelType> FuelTypes { get; set; }

        IQueryable<PricePerDay> GetAllPricesPerDay();
        IQueryable<SortingType> GetAllSortingTypes();
        IQueryable<CarbodyType> GetAllCarbodyTypes();
        IQueryable<FuelType> GetAllFuelTypes();
    }
}