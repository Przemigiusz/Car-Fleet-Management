using CarFleet_Project.Models.Interfaces;
using CarFleet_Project.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CarFleet_Project.Models.Contexts
{
    public class FilterContext : DbContext, IFilterContext
    {
        public FilterContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PricePerDay> PricesPerDay { get; set; }
        public DbSet<SortingType> SortingTypes { get; set; }
        public DbSet<CarbodyType> CarbodyTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }

        public IQueryable<PricePerDay> GetAllPricesPerDay() {
            return PricesPerDay;
        }
        public IQueryable<SortingType> GetAllSortingTypes() {
            return SortingTypes;
        }
        public IQueryable<CarbodyType> GetAllCarbodyTypes() {
            return CarbodyTypes;
        }
        public IQueryable<FuelType> GetAllFuelTypes() {
            return FuelTypes;
        }
    }
}
