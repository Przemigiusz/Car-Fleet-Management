using Microsoft.EntityFrameworkCore;

namespace CarFleet_Project.Models
{
    public interface IVehicleContext
    {
        DbSet<Vehicle> Vehicles { get; set; }

        int SaveChanges();
    }
}