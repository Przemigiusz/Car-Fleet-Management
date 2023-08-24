using CarFleet_Project.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace CarFleet_Project.Models.Interfaces
{
    public interface IEquipmentElementContext
    {
        DbSet<EquipmentElement> EquipmentElements { get; set; }
 
        IQueryable<EquipmentElement> GetAllEquipmentElements();
    }
}