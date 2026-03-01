using Microsoft.EntityFrameworkCore;
using MedicalDeviceMaintenance.Models;

namespace MedicalDeviceMaintenance.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Device> Devices => Set<Device>();
        public DbSet<Incident> Incidents => Set<Incident>();
        public DbSet<MaintenanceAction> MaintenanceActions => Set<MaintenanceAction>();
    }
}