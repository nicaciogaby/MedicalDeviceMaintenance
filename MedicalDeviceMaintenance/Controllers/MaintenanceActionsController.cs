using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalDeviceMaintenance.Data;
using MedicalDeviceMaintenance.Models;

namespace MedicalDeviceMaintenance.Controllers
{
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
            var appDbContext = _context.MaintenanceActions.Include(m => m.Incident);
            return View(await appDbContext.ToListAsync());
        }

        // GET: MaintenanceActions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceAction = await _context.MaintenanceActions
                .Include(m => m.Incident)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (maintenanceAction == null)
            {
                return NotFound();
            }

            return View(maintenanceAction);
        }

        // GET: MaintenanceActions/Create
        public IActionResult Create()
        {
            ViewData["IncidentId"] = new SelectList(_context.Incidents, "Id", "Title");
            return View();
        }

        // POST: MaintenanceActions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActionTaken,ActionDate,IncidentId")] MaintenanceAction maintenanceAction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maintenanceAction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IncidentId"] = new SelectList(_context.Incidents, "Id", "Title", maintenanceAction.IncidentId);
            return View(maintenanceAction);
        }

        // GET: MaintenanceActions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceAction = await _context.MaintenanceActions.FindAsync(id);
            if (maintenanceAction == null)
            {
                return NotFound();
            }
            ViewData["IncidentId"] = new SelectList(_context.Incidents, "Id", "Title", maintenanceAction.IncidentId);
            return View(maintenanceAction);
        }

        // POST: MaintenanceActions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActionTaken,ActionDate,IncidentId")] MaintenanceAction maintenanceAction)
        {
            if (id != maintenanceAction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maintenanceAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaintenanceActionExists(maintenanceAction.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IncidentId"] = new SelectList(_context.Incidents, "Id", "Title", maintenanceAction.IncidentId);
            return View(maintenanceAction);
        }

        // GET: MaintenanceActions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceAction = await _context.MaintenanceActions
                .Include(m => m.Incident)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maintenanceAction == null)
            {
                return NotFound();
            }

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
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaintenanceActionExists(int id)
        {
            return _context.MaintenanceActions.Any(e => e.Id == id);
        }
    }
}
