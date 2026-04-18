using MedicalDeviceMaintenance.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalDeviceMaintenance.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        private readonly AppDbContext _context;

        public StatisticsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Device status counts
            ViewBag.ActiveDevices = await _context.Devices
                .CountAsync(d => d.Status == "Active");
            ViewBag.MaintenanceDevices = await _context.Devices
                .CountAsync(d => d.Status == "Maintenance");
            ViewBag.RetiredDevices = await _context.Devices
                .CountAsync(d => d.Status == "Retired");
            ViewBag.OutOfServiceDevices = await _context.Devices
                .CountAsync(d => d.Status == "Out of Service");

            // Incident severity counts
            ViewBag.LowIncidents = await _context.Incidents
                .CountAsync(i => i.Severity == "Low");
            ViewBag.MediumIncidents = await _context.Incidents
                .CountAsync(i => i.Severity == "Medium");
            ViewBag.HighIncidents = await _context.Incidents
                .CountAsync(i => i.Severity == "High");
            ViewBag.CriticalIncidents = await _context.Incidents
                .CountAsync(i => i.Severity == "Critical");

            // Incident status counts
            ViewBag.OpenIncidents = await _context.Incidents
                .CountAsync(i => i.Status == "Open");
            ViewBag.InProgressIncidents = await _context.Incidents
                .CountAsync(i => i.Status == "In Progress");
            ViewBag.ResolvedIncidents = await _context.Incidents
                .CountAsync(i => i.Status == "Resolved");

            // Maintenance by technician
            ViewBag.MaintenanceByTechnician = await _context.MaintenanceActions
                .GroupBy(m => m.TechnicianName)
                .Select(g => new { Technician = g.Key, Count = g.Count() })
                .ToListAsync();

            // Incidents per month (last 6 months)
            var sixMonthsAgo = DateTime.Now.AddMonths(-6);
            ViewBag.IncidentsPerMonth = await _context.Incidents
                .Where(i => i.DateReported >= sixMonthsAgo)
                .GroupBy(i => new { i.DateReported.Year, i.DateReported.Month })
                .Select(g => new {
                    Month = g.Key.Month,
                    Year = g.Key.Year,
                    Count = g.Count()
                })
                .OrderBy(g => g.Year)
                .ThenBy(g => g.Month)
                .ToListAsync();

            return View();
        }
    }
}