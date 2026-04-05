using MedicalDeviceMaintenance.Data;
using MedicalDeviceMaintenance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MedicalDeviceMaintenance.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalDevices = await _context.Devices.CountAsync();
            ViewBag.ActiveDevices = await _context.Devices
                .CountAsync(d => d.Status == "Active");
            ViewBag.MaintenanceDevices = await _context.Devices
                .CountAsync(d => d.Status == "Maintenance");
            ViewBag.OpenIncidents = await _context.Incidents
                .CountAsync(i => i.Status == "Open");
            ViewBag.RecentIncidents = await _context.Incidents
                .Include(i => i.Device)
                .OrderByDescending(i => i.DateReported)
                .Take(5)
                .ToListAsync();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}