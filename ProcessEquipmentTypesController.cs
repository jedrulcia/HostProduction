using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HostProduction.Data;

namespace HostProduction
{
    public class ProcessEquipmentTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProcessEquipmentTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProcessEquipmentTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProcessEquipmentTypes.ToListAsync());
        }

        // GET: ProcessEquipmentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processEquipmentType = await _context.ProcessEquipmentTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processEquipmentType == null)
            {
                return NotFound();
            }

            return View(processEquipmentType);
        }

        // GET: ProcessEquipmentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcessEquipmentTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,Area")] ProcessEquipmentType processEquipmentType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processEquipmentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(processEquipmentType);
        }

        // GET: ProcessEquipmentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processEquipmentType = await _context.ProcessEquipmentTypes.FindAsync(id);
            if (processEquipmentType == null)
            {
                return NotFound();
            }
            return View(processEquipmentType);
        }

        // POST: ProcessEquipmentTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,Area")] ProcessEquipmentType processEquipmentType)
        {
            if (id != processEquipmentType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processEquipmentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessEquipmentTypeExists(processEquipmentType.Id))
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
            return View(processEquipmentType);
        }

        // GET: ProcessEquipmentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processEquipmentType = await _context.ProcessEquipmentTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processEquipmentType == null)
            {
                return NotFound();
            }

            return View(processEquipmentType);
        }

        // POST: ProcessEquipmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processEquipmentType = await _context.ProcessEquipmentTypes.FindAsync(id);
            if (processEquipmentType != null)
            {
                _context.ProcessEquipmentTypes.Remove(processEquipmentType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessEquipmentTypeExists(int id)
        {
            return _context.ProcessEquipmentTypes.Any(e => e.Id == id);
        }
    }
}
