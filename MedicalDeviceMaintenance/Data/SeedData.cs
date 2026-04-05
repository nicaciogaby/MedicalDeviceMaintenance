using MedicalDeviceMaintenance.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalDeviceMaintenance.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            if (context.Devices.Any())
            {
                return;
            }

            var devices = new List<Device>
            {
                new Device
                {
                    Name = "Infusion Pump A",
                    SerialNumber = "INF-1001",
                    Model = "IP-200",
                    Manufacturer = "MedEquip",
                    Location = "Ward 1",
                    PurchaseDate = new DateTime(2023, 5, 10),
                    Status = "Active"
                },
                new Device
                {
                    Name = "ECG Monitor B",
                    SerialNumber = "ECG-2045",
                    Model = "ECG-Pro",
                    Manufacturer = "HealthTech",
                    Location = "ICU",
                    PurchaseDate = new DateTime(2022, 11, 20),
                    Status = "Active"
                },
                new Device
                {
                    Name = "Defibrillator C",
                    SerialNumber = "DEF-7788",
                    Model = "SafeShock X",
                    Manufacturer = "LifeMed",
                    Location = "Emergency Room",
                    PurchaseDate = new DateTime(2021, 8, 15),
                    Status = "Maintenance"
                }
            };

            context.Devices.AddRange(devices);
            context.SaveChanges();

            var incidents = new List<Incident>
            {
                new Incident
                {
                    Title = "Battery not charging",
                    Description = "The battery does not hold charge properly.",
                    DateReported = DateTime.Now.AddDays(-7),
                    Severity = "High",
                    Status = "Open",
                    DeviceId = devices[0].Id
                },
                new Incident
                {
                    Title = "Screen display failure",
                    Description = "The monitor screen flickers during operation.",
                    DateReported = DateTime.Now.AddDays(-5),
                    Severity = "Medium",
                    Status = "In Progress",
                    DeviceId = devices[1].Id
                }
            };

            context.Incidents.AddRange(incidents);
            context.SaveChanges();

            var maintenanceActions = new List<MaintenanceAction>
            {
                new MaintenanceAction
    {
        ActionTaken = "Battery replaced",
        ActionDate = DateTime.Now.AddDays(-3),
        TechnicianName = "John Murphy",
        Notes = "New battery installed and tested successfully.",
        IncidentId = incidents[0].Id
    },
    new MaintenanceAction
    {
        ActionTaken = "Screen calibration completed",
        ActionDate = DateTime.Now.AddDays(-2),
        TechnicianName = "Sarah O'Brien",
        Notes = "Calibration completed according to manufacturer guidelines.",
        IncidentId = incidents[1].Id
                }
            };

            context.MaintenanceActions.AddRange(maintenanceActions);
            context.SaveChanges();
        }
    }
}