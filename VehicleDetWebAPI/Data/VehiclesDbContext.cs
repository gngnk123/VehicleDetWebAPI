using Microsoft.EntityFrameworkCore;
using VehicleDetWebAPI.Model;

namespace VehicleDetWebAPI.Data
{
    public class VehiclesDbContext : DbContext
    {
        public VehiclesDbContext(DbContextOptions options) : base(options) 
        { 
        
        }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
