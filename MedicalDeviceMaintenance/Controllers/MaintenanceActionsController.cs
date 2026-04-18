using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalDeviceMaintenance.Data;
using MedicalDeviceMaintenance.Models;
using Microsoft.AspNetCore.Authorization;

namespace MedicalDeviceMaintenance.Controllers
{
    [Authorize]
    public class MaintenanceActionsController : Controller
    {
        private readonly AppDbContext _context;

        public MaintenanceActionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MaintenanceActions
        public async Task<IActionResult> Index()
        {
            var actions = _context.MaintenanceActions
                .Include(m => m.Incident)
                    .ThenInclude(i => i.Device);
            return View(await actions.ToListAsync());
        }

        // GET: MaintenanceActions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var maintenanceAction = await _context.MaintenanceActions
                .Include(m => m.Incident)
                    .ThenInclude(i => i.Device)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (maintenanceAction == null) return NotFound();

            return View(maintenanceAction);
        }

        // GET: MaintenanceActions/Create
        public IActionResult Create()
        {
            ViewData["IncidentId"] = new SelectList(
                _context.Incidents.Include(i => i.Device)
                    .Select(i => new {
                        i.Id,
                        Display = i.Device.Name + " — " + i.Title
                    }),
                "Id", "Display");
            return View();
        }

        // POST: MaintenanceActions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,ActionTaken,ActionDate,TechnicianName,Notes,IncidentId")] MaintenanceAction maintenanceAction)
        {
            if (ModelState.IsValid)
            {
                maintenanceAction.ActionDate = DateTime.Now;
                _context.Add(maintenanceAction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IncidentId"] = new SelectList(
                _context.Incidents.Include(i => i.Device)
                    .Select(i => new {
                        i.Id,
                        Display = i.Device.Name + " — " + i.Title
                    }),
                "Id", "Display", maintenanceAction.IncidentId);
            return View(maintenanceAction);
        }

        // GET: MaintenanceActions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var maintenanceAction = await _context.MaintenanceActions.FindAsync(id);
            if (maintenanceAction == null) return NotFound();

            ViewData["IncidentId"] = new SelectList(
                _context.Incidents.Include(i => i.Device)
                    .Select(i => new {
                        i.Id,
                        Display = i.Device.Name + " — " + i.Title
                    }),
                "Id", "Display", maintenanceAction.IncidentId);
            return View(maintenanceAction);
        }

        // POST: MaintenanceActions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,ActionTaken,ActionDate,TechnicianName,Notes,IncidentId")] MaintenanceAction maintenanceAction)
        {
            if (id != maintenanceAction.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maintenanceAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaintenanceActionExists(maintenanceAction.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["IncidentId"] = new SelectList(
                _context.Incidents.Include(i => i.Device)
                    .Select(i => new {
                        i.Id,
                        Display = i.Device.Name + " — " + i.Title
                    }),
                "Id", "Display", maintenanceAction.IncidentId);
            return View(maintenanceAction);
        }

        // GET: MaintenanceActions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var maintenanceAction = await _context.MaintenanceActions
                .Include(m => m.Incident)
                    .ThenInclude(i => i.Device)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (maintenanceAction == null) return NotFound();

            return View(maintenanceAction);
        }

        // POST: MaintenanceActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maintenanceAction = await _context.MaintenanceActions.FindAsync(id);
            if (maintenanceAction != null)
            {
                _context.MaintenanceActions.Remove(maintenanceAction);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool MaintenanceActionExists(int id)
        {
            return _context.MaintenanceActions.Any(e => e.Id == id);
        }
    }
}
