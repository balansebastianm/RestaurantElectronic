#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantElectronic.Data;
using RestaurantElectronic.Models;

namespace RestaurantElectronic.Controllers
{
    public class MeniusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeniusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Menius
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meniu.ToListAsync());
        }

        // GET: Menius/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meniu = await _context.Meniu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meniu == null)
            {
                return NotFound();
            }

            return View(meniu);
        }

        // GET: Menius/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menius/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Weight")] Meniu meniu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meniu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meniu);
        }

        // GET: Menius/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meniu = await _context.Meniu.FindAsync(id);
            if (meniu == null)
            {
                return NotFound();
            }
            return View(meniu);
        }

        // POST: Menius/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Weight")] Meniu meniu)
        {
            if (id != meniu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meniu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeniuExists(meniu.Id))
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
            return View(meniu);
        }

        // GET: Menius/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meniu = await _context.Meniu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meniu == null)
            {
                return NotFound();
            }

            return View(meniu);
        }

        // POST: Menius/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meniu = await _context.Meniu.FindAsync(id);
            _context.Meniu.Remove(meniu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeniuExists(int id)
        {
            return _context.Meniu.Any(e => e.Id == id);
        }
    }
}
