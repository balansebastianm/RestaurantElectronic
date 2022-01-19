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
    public class IstoricComenzisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IstoricComenzisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IstoricComenzis
        public async Task<IActionResult> Index()
        {
            return View(await _context.IstoricComenzi.ToListAsync());
        }

        // GET: IstoricComenzis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var istoricComenzi = await _context.IstoricComenzi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (istoricComenzi == null)
            {
                return NotFound();
            }

            return View(istoricComenzi);
        }

        // GET: IstoricComenzis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IstoricComenzis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,UserId,CreatedDate,TotalPrice")] IstoricComenzi istoricComenzi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(istoricComenzi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(istoricComenzi);
        }

        // GET: IstoricComenzis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var istoricComenzi = await _context.IstoricComenzi.FindAsync(id);
            if (istoricComenzi == null)
            {
                return NotFound();
            }
            return View(istoricComenzi);
        }

        // POST: IstoricComenzis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,UserId,CreatedDate,TotalPrice")] IstoricComenzi istoricComenzi)
        {
            if (id != istoricComenzi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(istoricComenzi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IstoricComenziExists(istoricComenzi.Id))
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
            return View(istoricComenzi);
        }

        // GET: IstoricComenzis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var istoricComenzi = await _context.IstoricComenzi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (istoricComenzi == null)
            {
                return NotFound();
            }

            return View(istoricComenzi);
        }

        // POST: IstoricComenzis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var istoricComenzi = await _context.IstoricComenzi.FindAsync(id);
            _context.IstoricComenzi.Remove(istoricComenzi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IstoricComenziExists(int id)
        {
            return _context.IstoricComenzi.Any(e => e.Id == id);
        }
    }
}
