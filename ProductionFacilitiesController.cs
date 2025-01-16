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
    public class ProductionFacilitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductionFacilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductionFacilities
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductionFacilities.ToListAsync());
        }

        // GET: ProductionFacilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionFacility = await _context.ProductionFacilities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productionFacility == null)
            {
                return NotFound();
            }

            return View(productionFacility);
        }

        // GET: ProductionFacilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductionFacilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,StandardArea")] ProductionFacility productionFacility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productionFacility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productionFacility);
        }

        // GET: ProductionFacilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionFacility = await _context.ProductionFacilities.FindAsync(id);
            if (productionFacility == null)
            {
                return NotFound();
            }
            return View(productionFacility);
        }

        // POST: ProductionFacilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,StandardArea")] ProductionFacility productionFacility)
        {
            if (id != productionFacility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productionFacility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionFacilityExists(productionFacility.Id))
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
            return View(productionFacility);
        }

        // GET: ProductionFacilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionFacility = await _context.ProductionFacilities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productionFacility == null)
            {
                return NotFound();
            }

            return View(productionFacility);
        }

        // POST: ProductionFacilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productionFacility = await _context.ProductionFacilities.FindAsync(id);
            if (productionFacility != null)
            {
                _context.ProductionFacilities.Remove(productionFacility);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionFacilityExists(int id)
        {
            return _context.ProductionFacilities.Any(e => e.Id == id);
        }
    }
}
