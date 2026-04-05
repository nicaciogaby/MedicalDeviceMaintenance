using MedicalDeviceMaintenance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicalDeviceMaintenance.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
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

            modelBuilder.Entity<Incident>()
                .HasOne(i => i.Device)
                .WithMany(d => d.Incidents)
                .HasForeignKey(i => i.DeviceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MaintenanceAction>()
                .HasOne(m => m.Incident)
                .WithMany(i => i.MaintenanceActions)
                .HasForeignKey(m => m.IncidentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}