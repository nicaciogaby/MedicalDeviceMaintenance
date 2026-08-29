using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalDeviceMaintenance.Data;
using MedicalDeviceMaintenance.Models;
using Microsoft.AspNetCore.Authorization;

namespace MedicalDeviceMaintenance.Controllers
{
    [Authorize]
    public class DevicesController : Controller
    {
        private readonly AppDbContext _context;

        public DevicesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            var devices = await _context.Devices
                .Include(d => d.Incidents)
                .ToListAsync();
            return View(devices);
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var device = await _context.Devices
                .Include(d => d.Incidents)
                    .ThenInclude(i => i.MaintenanceActions)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (device == null) return NotFound();

            return View(device);
        }

        // GET: Devices/Create
        [Authorize(Roles = "Admin,Technician")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Devices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Technician")]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,SerialNumber,Model,Manufacturer,Location,PurchaseDate,Status")] Device device)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(device);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = $"Device \"{device.Name}\" was created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    TempData["Error"] = "Something went wrong while creating the device. Please try again.";
                    return View(device);
                }
            }
            return View(device);
        }

        // GET: Devices/Edit/5
        [Authorize(Roles = "Admin,Technician")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var device = await _context.Devices.FindAsync(id);
            if (device == null) return NotFound();

            return View(device);
        }

        // POST: Devices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Technician")]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Name,SerialNumber,Model,Manufacturer,Location,PurchaseDate,Status")] Device device)
        {
            if (id != device.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(device);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = $"Device \"{device.Name}\" was updated successfully.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceExists(device.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        TempData["Error"] = "This device was modified by someone else. Please try again.";
                        return View(device);
                    }
                }
                catch (Exception)
                {
                    TempData["Error"] = "Something went wrong while saving changes. Please try again.";
                    return View(device);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(device);
        }

        // GET: Devices/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var device = await _context.Devices
                .Include(d => d.Incidents)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (device == null) return NotFound();

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var device = await _context.Devices
                .Include(d => d.Incidents)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (device != null)
            {
                try
                {
                    var deviceName = device.Name;
                    _context.Devices.Remove(device);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = $"Device \"{deviceName}\" was deleted.";
                }
                catch (Exception)
                {
                    TempData["Error"] = "Something went wrong while deleting the device. Please try again.";
                }
            }
            else
            {
                TempData["Error"] = "Device not found. It may have already been deleted.";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(int id)
        {
            return _context.Devices.Any(e => e.Id == id);
        }
    }
}
