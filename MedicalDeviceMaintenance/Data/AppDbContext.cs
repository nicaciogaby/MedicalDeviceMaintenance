using MedicalDeviceMaintenance.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalDeviceMaintenance.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<MaintenanceAction> MaintenanceActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Device → Incidents (one to many)
            // If a Device is deleted, all its Incidents are deleted too
            modelBuilder.Entity<Incident>()
                .HasOne(i => i.Device)
                .WithMany(d => d.Incidents)
                .HasForeignKey(i => i.DeviceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Incident → MaintenanceActions (one to many)
            // If an Incident is deleted, all its MaintenanceActions are deleted too
            modelBuilder.Entity<MaintenanceAction>()
                .HasOne(m => m.Incident)
                .WithMany(i => i.MaintenanceActions)
                .HasForeignKey(m => m.IncidentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}