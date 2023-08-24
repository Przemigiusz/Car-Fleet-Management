﻿using CarFleet_Project.Models.Interfaces;
using CarFleet_Project.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CarFleet_Project.Models.Contexts
{
    public class FilterContext : DbContext, IFilterContext
    {
        public FilterContext(DbContextOptions<FilterContext> options) : base(options)
        {
        }

        public DbSet<PriceType> PriceTypes { get; set; }
        public DbSet<SortingType> SortingTypes { get; set; }
        public DbSet<CarbodyType> CarbodyTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }

        public IQueryable<PriceType> GetAllPriceTypes() {
            return PriceTypes;
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
        public IQueryable<TransmissionType> GetAllTransmissionTypes()
        {
            return TransmissionTypes;
        }
    }
}
