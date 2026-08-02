using MedicalDeviceMaintenance.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalDeviceMaintenance.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatisticsController : Controller
    {
        private readonly AppDbContext _context;

        public StatisticsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var deviceStatusCounts = await _context.Devices
                .GroupBy(d => d.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToListAsync();

            ViewBag.DeviceStatusLabels = deviceStatusCounts.Select(x => x.Status).ToList();
            ViewBag.DeviceStatusData = deviceStatusCounts.Select(x => x.Count).ToList();

            var severityCounts = await _context.Incidents
                .GroupBy(i => i.Severity)
                .Select(g => new { Severity = g.Key, Count = g.Count() })
                .ToListAsync();

            ViewBag.SeverityLabels = severityCounts.Select(x => x.Severity).ToList();
            ViewBag.SeverityData = severityCounts.Select(x => x.Count).ToList();

            var sixMonthsAgo = DateTime.Now.AddMonths(-5);
            var incidentsByMonth = await _context.Incidents
                .Where(i => i.DateReported >= new DateTime(sixMonthsAgo.Year, sixMonthsAgo.Month, 1))
                .ToListAsync();

            var monthBuckets = Enumerable.Range(0, 6)
                .Select(offset => DateTime.Now.AddMonths(-5 + offset))
                .Select(d => new { Year = d.Year, Month = d.Month, Label = d.ToString("MMM yyyy") })
                .ToList();

            var monthlyLabels = monthBuckets.Select(b => b.Label).ToList();
            var monthlyData = monthBuckets
                .Select(b => incidentsByMonth.Count(i => i.DateReported.Year == b.Year && i.DateReported.Month == b.Month))
                .ToList();

            ViewBag.MonthlyLabels = monthlyLabels;
            ViewBag.MonthlyData = monthlyData;

            var byTechnician = await _context.MaintenanceActions
                .GroupBy(m => m.TechnicianName)
                .Select(g => new { Technician = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(8)
                .ToListAsync();

            ViewBag.TechnicianLabels = byTechnician.Select(x => x.Technician).ToList();
            ViewBag.TechnicianData = byTechnician.Select(x => x.Count).ToList();

            ViewBag.TotalDevices = await _context.Devices.CountAsync();
            ViewBag.TotalIncidents = await _context.Incidents.CountAsync();
            ViewBag.TotalMaintenanceActions = await _context.MaintenanceActions.CountAsync();
            ViewBag.AvgIncidentsPerDevice = ViewBag.TotalDevices > 0
                ? Math.Round((double)ViewBag.TotalIncidents / (int)ViewBag.TotalDevices, 1)
                : 0;

            return View();
        }
    }
}